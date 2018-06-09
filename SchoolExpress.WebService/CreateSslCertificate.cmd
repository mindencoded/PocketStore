@ECHO OFF
:: Creating a self-signed certificate, we need to provide a configuration file to OpenSSL and define the SAN in that configuration file.
openssl.exe req -new -sha256 -newkey rsa:2048 -nodes -keyout "ca.key" -x509 -days 365 -out "ca.crt" -config "ca.conf" -subj "/CN=schoolexpress.com/O=schoolexpress/C=PE/ST=Lima/L=Lima/emailAddress=contact@schoolexpress.com"
:: Converting PEM encoded Certificate and private key to PKCS #12 / PFX
openssl.exe pkcs12 -export -out "ca.pfx" -inkey "ca.key" -in "ca.crt" -passout pass:
PAUSE