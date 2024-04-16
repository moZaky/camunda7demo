
## Installation

To start the latest release:


```bash
docker pull camunda/camunda-bpm-platform:latest
docker run -d --name camunda -p 8080:8080 camunda/camunda-bpm-platform:latest
# open browser with url: http://localhost:8080/camunda-welcome/index.html
```

## Deploy workflow from porject

## workflowPayload

```json
{
  "address": {
    "value": "123 Main Street"
  },
"tenantId": {
"value": "646b42bbe93063c0f449dfe8"
},
"__createdByUsername": {
"value": "mohammed.elkassed@mySite.com"
},
  "address2": {
    "value": "Apt 4B"
  },
  "phone": {
    "value": "555-1234"
  },
    "type": {
    "value": null
  },
  "name": {
    "value": "My Organization"
  }
}
```
## workflowPayload for skip demo

```json
{
  "address": {
    "value": "123 Main Street"
  },
 "userType": {
    "value": "superUser"
  }
}
```
