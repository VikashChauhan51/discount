# discount

## Install Grpc UI
  - Install [golang](https://go.dev/).
- install [Grpcui](https://github.com/fullstorydev/grpcui) `go install github.com/fullstorydev/grpcui/cmd/grpcui@latest`.

## Use Grpc UI
- `grpcui -plaintext localhost:<service_port>`.
- `grpcui -plaintext localhost:12345`.


## Connect Diccount
The Discount gRPC service is running on two ports: `7299` (HTTPS) and `5155` (HTTP).

You can connect to the HTTP port by using the following command:

```shell
grpcui -plaintext localhost:5155
```

If you want to connect to the HTTPS port (`7299`), you might need to provide the certificate details. Here's an example:

```shell
grpcui -cacert /path/to/cert.pem localhost:7299
```

Replace `/path/to/cert.pem` with the path to your certificate file.

