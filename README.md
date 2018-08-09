# New CDN iTaas

## Challenge 

Log files can tell much about a system’s behavior in a production environment. Extracting data from these files helps the decision-making process for both business and development roadmap.

iTaaS Solution is a company focused on content delivery, and one of its largest business challenges was CDN (Content Delivery Network) costs. Larger CDN costs increase the final pricing for its customers, reduce profits, and make it difficult to enter smaller markets.

After extensive research from their software engineers and financial team, they obtained an excellent deal from the company “MINHA CDN”, and signed a one-year contract with them.

iTaaS Solution already has a system capable of generating billing reports from logs, called “Agora”. However, it uses a specific log format, different from the format used by ”MINHA CDN”.

You have been hired by iTaaS Solution to develop a system that can convert log files to the desired format, which means that at this moment they need to convert them from the “MINHA CDN” format to the “Agora” format.

This is a sample log file in the “MINHA CDN” format.

```
312|200|HIT|"GET /robots.txt HTTP/1.1"|100.2
101|200|MISS|"POST /myImages HTTP/1.1"|319.4
199|404|MISS|"GET /not-found HTTP/1.1"|142.9
312|200|INVALIDATE|"GET /robots.txt HTTP/1.1"|245.1
```

The sample above should generate the following log in the “Agora” format:

```
#Version: 1.0
#Date: 15/12/2017 23:01:06
#Fields: provider http-method status-code response-size cache-status uri-path time-taken
"MINHA CDN" GET 200 /robots.txt 100 312 HIT
"MINHA CDN" POST 200 /myImages 319 101 MISS
"MINHA CDN" GET 404 /not-found 143 199 MISS
"MINHA CDN" GET 200 /robots.txt 245 312 REFRESH_HIT
```

“MINHA CDN” will make log files through specific URLs.

The specification requires you to implement a solution that receives as input an URL (sourceUrl) and a destination file (targetPath). A sample call could be:

convert http://logstorage.com/minhaCdn1.txt ./output/minhaCdn1.txt

The sourceUrl parameter includes a file in the “MINHA CDN” format, and the output specified in the targetPath parameter corresponds to the file that needs to be created in the “Agora” format.

A sample log file that can be used for testing is available here:

https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt

Beware that what will be analyzed on this exercise is the not only the correction of the code but also code best practices, like OOP, SOLID, unit tests and mocks.

## System Requirements
* **[.NET Core](https://www.microsoft.com/net/download)** (version >= 2.1).

## Installing

### Ubuntu 18.04
* dotnet publish AgoraLogger/ -c release -r ubuntu.16.10-x64 -o OUTPUT_FOLDER

### Windows 10
* dotnet publish AgoraLogger/ -c release -r win10-x64 -o OUTPUT_FOLDER

## Running Application

### Ubuntu 
* ./AgoraLogger $SOURCE_URL $OUTPUT_PATH

### Windows
* AgoraLogger.exe $SOURCE_URL $OUTPUT_PATH

## Running Unit Tests

From inside the UnitTest folder, run:

* dotnet test