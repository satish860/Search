// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Search.Domain;
using System.Text.Json;
using Typesense;
using Typesense.Setup;

var provider = new ServiceCollection()
    .AddTypesenseClient(config =>
    {
        config.ApiKey = "key";
        config.Nodes = new List<Node>
        {
            new Node("localhost", "8108", "http")
        };
    }).BuildServiceProvider();

var deviceid = 0;
var displaymodel = new[] {
    "Apple",
    "Desktop",
    "Falcon-Windows",
    "iPad mini 4 (7.9-inch, 4th generation) (32 GB Space Gray)" ,
    "MacBook Pro Core i5/i7 13 (Mid-2012)",
    "samsung SM-G928V",
    "Windows Spoofer"
};

var departments = new Dictionary<int, string>
{
    {572, "California" },
    {571,"Bangalore" },
    {573, "Atlanta"},
    {547,"Japan" }
};

Randomizer.Seed = new Random(8675309);

var devices = new Faker<Device>()
      .RuleFor(p => p.Id, f => deviceid++.ToString())
      .RuleFor(p => p.DisplayModel, f => f.PickRandom(displaymodel))
      .RuleFor(p => p.Domain, f => f.Internet.DomainName())
      .RuleFor(p => p.FirstName, f => f.Name.FirstName())
      .RuleFor(p => p.LastName, f => f.Name.LastName())
      .RuleFor(p => p.FullName, (f, u) => u.FirstName + " " + u.LastName)
      .RuleFor(p => p.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
      .RuleFor(p => p.AssetNumber, f => f.Finance.BitcoinAddress().OrNull(f))
      .RuleFor(p => p.MACAddress, f => f.Internet.Mac(""))
      .RuleFor(p => p.CurrentIPAddress, f => f.Internet.IpAddress().ToString())
      .RuleFor(p => p.EmailAddress, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
      .RuleFor(p => p.PhoneNumber, f => f.Phone.PhoneNumberFormat(5).OrNull(f, 0.1f))
      .RuleFor(p => p.LastSeen, f => f.Date.Past())
      .RuleFor(p => p.OSVersion, (f, u) =>
      {
          if (u.DisplayModel == "samsung SM-G928V")
              return "6.0.1";
          else if (u.DisplayModel == "iPad mini 4 (7.9-inch, 4th generation) (32 GB Space Gray)")
          {

              return "10.2.1";
          }
          else if (u.DisplayModel == "MacBook Pro Core i5/i7 13 (Mid-2012)")
          {
              return "10.13.6";
          }
          else if (u.DisplayModel == "Desktop" || u.DisplayModel == "Falcon-Windows")
          {
              return "10.0.17134";
          }
          else if (u.DisplayModel == "Windows Spoofer")
          {
              return "10.0.14393";
          }
          return string.Empty;
      }
      )
      .RuleFor(p => p.DeviceType, (f, u) =>
      {
          if (u.DisplayModel == "samsung SM-G928V")
              return "Android";
          else if (u.DisplayModel == "iPad mini 4 (7.9-inch, 4th generation) (32 GB Space Gray)")
          {
              return "Apple";
          }
          else if (u.DisplayModel == "MacBook Pro Core i5/i7 13 (Mid-2012)")
          {
              return "AppleOsX";
          }
          else if (u.DisplayModel == "Desktop" || u.DisplayModel == "Falcon-Windows")
          {
              return "WinRT";
          }
          else if (u.DisplayModel == "Windows Spoofer")
          {
              return "WinRT";
          }
          return string.Empty;
      }
      )
      .RuleFor(p => p.LocationGroupID, (f, u) => f.PickRandom<int>(departments.Keys))
      .RuleFor(p => p.LocationGroupName, (f, u) => { return departments[u.LocationGroupID]; })
      .RuleFor(p => p.FriendlyName, (f, u) => u.UserName + " " + u.DisplayModel + " " + f.UniqueIndex)
      .Generate(700000);

var schema = new Schema(
    "devices",
    new List<Field>
    {
        new Field("id", FieldType.String, false),
        new Field("display_model", FieldType.String, false),
        new Field("friendly_name", FieldType.String, false, true),
        new Field("name", FieldType.String, false, true),
        new Field("phone_number",FieldType.String,false,true),
        new Field("serial_number",FieldType.String,false,true),
        new Field("hardware_identifier",FieldType.String,false,false),
        new Field("location_group_id",FieldType.Int32,false,true,false),
        new Field("asset_number",FieldType.String,false,false),
        new Field("user_name",FieldType.String,false,false),
        new Field("domain",FieldType.String,false,false),
        new Field("first_name",FieldType.String,false,false),
        new Field("middle_name",FieldType.String,false,true,false),
        new Field("last_name",FieldType.String,false,false),
        new Field("full_name",FieldType.String,false,false),
        new Field("email_address",FieldType.String,false,false),
        new Field("employee_identifier",FieldType.String,false,true,false),
        new Field("cost_center",FieldType.String,false,true,false),
        new Field("lg_name",FieldType.String,false,false),
        new Field("mac_address",FieldType.String,false,false),
        new Field("currentip_address",FieldType.String,false,false),
        new Field("os_version",FieldType.String,false,true,false),
        new Field("device_type",FieldType.String,false,true,false),
        new Field("last_seen",FieldType.String,false,false)
    });

var typesenseClient = provider.GetService<ITypesenseClient>();

var createCollectionResult = await typesenseClient.CreateCollection(schema);


var importDocumentResults = await typesenseClient.ImportDocuments<Device>("devices", devices, 40, ImportType.Upsert);

