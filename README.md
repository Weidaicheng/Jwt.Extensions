# Jwt.Extensions
###### Extensions for jwt([https://github.com/jwt-dotnet/jwt](https://github.com/jwt-dotnet/jwt)) and asp.net core 2.0

### What's this for
It's easy for you to use Jwt when you're using asp.net core 2.0.

For example, if I want to create a token without this extension in asp.net core 2.0, I should write the code below:

```
var payload = new Dictionary<string, object>
{
    { "claim1", 0 },
    { "claim2", "claim2-value" }
};
const string secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
IJsonSerializer serializer = new JsonNetSerializer();
IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);

var token = encoder.Encode(payload, secret);
Console.WriteLine(token);
```
as you can see, I should `new` a few of instance to create the token I want.
After using this extension,I can use the DI system to get the instance of `IJwtEncoder` interface, then I just need to write a few code below:
```
var payload = new Dictionary<string, object>
{
    { "claim1", 0 },
    { "claim2", "claim2-value" }
};

var token = _jwtEncoder.Encode(payload, secret);
```
### How to install
Using the commond below in the Package Manager
`Install-Package Jwt.Extensions`
### How to use
##### 1. Add Jwt.Extensions to the DI system

If you just need to use the `IJwtEncoder` or `IJwtDecoder` easily, you could modify your `Startup` class and add `services.AddJwt();` to the `ConfigureServices` method.

This will use the default configuration listed below:

* `HMACSHA256Algorithm` as `IJwtAlgorithm`
* `UtcDateTimeProvider` as `IDateTimeProvider`
* `JsonNetSerializer` as `IJsonSerializer`
* `JwtBase64UrlEncoder` as `IBase64UrlEncoder`

##### 2. Inject the `IJwtEncoder` or `IJwtDecoder` from the construction method

You can write the code like blow to use the `IJwtEncoder` or `IJwtDecoder`:
```
public class MyClass
{
	private readonly IJwtEncoder _jwtEncoder;
	private readonly IJwtDecoder _jwtDecoder;
	
	public MyClass(IJwtEncoder jwtEncoder, IJwtDecoder jwtDecoder)
	{
		_jwtEncoder = jwtEncoder;
		_jwtDecoder = jwtDecoder;
	}
}
```
then you can use them in you class.

### The `TryDecode` extension methods
These methods use the `Decode` methods within its implement and the verify flag is always `true`,they're listed below:
* `bool TryDecode(string token, string key, out string result)`
* `bool TryDecode(string token, byte[] key, out string result)`
* `bool TryDecodeToObject(string token, string key, out IDictionary<string, object> result)`
* `bool TryDecodeToObject(string token, byte[] key, out IDictionary<string, object> result)`
* `bool TryDecodeToObject<T>(string token, string key, out T result)`
* `bool TryDecodeToObject<T>(string token, byte[] key, out T result)`

### The `Payload` class
Defining a Payload class which includes the basic properties such as `sub`, `iss`, `aud` and `exp`.

### Asp.net Core token auto authentication
The `JwtControllerBase` class is inherited from `Controller` class and override the `OnActionExecuting` method to verify the token.
To use this future, please follow the steps below:
##### 1.Add Jwt.Extensions to the DI system

Modifying the `Startup` class and adding the folowing code into the `ConfigureServices` class:
```
services.AddJwt(opt =>
{
	opt.Bearer = TokenBearer.QueryString;
	opt.TokenBearerKey = "SomeKey";
	opt.SecretStr = "secret";
	opt.RedirectAction = "Login";
	opt.RedirectController = "User";
});
```
* `Bearer` means where is the location to bearer the token
* `TokenBearerKey` means which key is the bearer key, the default key is "Token"
* `SecretStr` means the jwt secret, you can also use the `SecretBytes` to provide a `byte[]` type key
* `RedirectAction` means which action you want to redirect after the token is illegal
* `RedirectController` means which controller you want to redirect after the token is illegal
###### Something Important: If you provide both `SecretStr` and `SecretBytes` the `SecretStr` would be used by default, if you don't provide `SecretStr` nor `SecretBytes`, there would be a `NoSecretSpecifiedException` exception be thrown.

##### 2.Change the controller's base class as `JwtControllerBase`
Using the following code to define a controller:
```
public class AdminController : JwtControllerBase
```

##### 3.Set the `JwtCheck` attribute
Setting the `JwtCheck` attribute to the controller or action which needs to be authorized, for example
```
[JwtCheck]
public class AdminController : JwtControllerBase
```
or
```
public class AdminController : JwtControllerBase
{
	[JwtCheck]
	public ActionResult Index()
	{
		return View();
	}
}
```
If some methods don't need to be authorize, you can use like this:
```
[JwtCheck]
public class AdminController : JwtControllerBase
{
	public ActionResult Index()
	{
		return View();
	}

	[JwtCheck(Ignore = true)]
	public ActionResult Login()
	{
		return View();
	}
}
```
### To-do list
##### 1.Add more configurations that you can specify which kind of algorithm or datetimeprovider and so on you want tot use.
##### 2.Add redirect link that you can redirect to another link instead of controller and action after the token is not authorized.