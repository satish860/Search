using System.Text.Json.Serialization;

namespace Search.Domain
{
    
    public class Device
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("display_model")]
        public string DisplayModel { get; set; }

        [JsonPropertyName("friendly_name")]
        public string FriendlyName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("serial_number")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("hardware_identifier")]
        public string HardwareIdentifier { get; set; }

        [JsonPropertyName("location_group_id")]
        public int LocationGroupID { get; set; }

        [JsonPropertyName("asset_number")]
        public string AssetNumber { get; set; }

        [JsonPropertyName("user_name")]
        public string UserName { get; set; }

        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("full_name")]
        public string FullName { get; set; }

        [JsonPropertyName("email_address")]
        public string EmailAddress { get; set; }

        [JsonPropertyName("employee_identifier")]
        public string EmployeeIdentifier { get; set; }

        [JsonPropertyName("cost_center")]
        public string CostCenter { get; set; }

        [JsonPropertyName("lg_name")]
        public string LocationGroupName { get; set; }

        [JsonPropertyName("mac_address")]
        public string MACAddress { get; set; }

        [JsonPropertyName("currentip_address")]
        public string CurrentIPAddress { get; set; }

        [JsonPropertyName("os_version")]
        public string OSVersion { get; set; }

        [JsonPropertyName("device_type")]
        public string DeviceType { get; set; }

        [JsonPropertyName("last_seen")]
        public DateTime LastSeen { get; set; }

    }
}