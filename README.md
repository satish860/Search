# Search
This project contains the example implementation of Device search in a IOT setup using Typesense. 

# Project vision
Achieve instant sub-50ms searches for Large device fleet. We will include multiple search entity as part of the device like Application installed, Configuration of the device and contents like Files the device may have.

Following are the features we will be implement and performance test the same. 

1. Multiple Index search - https://typesense.org/docs/0.22.2/api/documents.html#federated-multi-search
2. Import using JSON - https://typesense.org/docs/0.22.2/api/documents.html#import-a-jsonl-file
3. Implement Filters  - https://typesense.org/docs/0.22.2/api/documents.html#filter-results
4. Paging the records - https://typesense.org/docs/0.22.2/api/documents.html#pagination
5. Facets   - https://typesense.org/docs/0.22.2/api/documents.html#facet-results
6. Ingesting the records at High speed - This will be optional and experimental Feature . 

# Tech Stack
We will be using the following Tech stack. 

1. FastApiEndpoints - https://fast-endpoints.com/index.html. Dotnet based API framework which provides the sane default and high scalablity.
2. TypeSense -  https://typesense.org/ . Lightening Fast Open source search Engine.
3. We are still evaluting Nats vs Apache Pulser.

# Data
We use tools like Faker to mock the data. This will also be open sourced for anyone to generate the device data. 
    
