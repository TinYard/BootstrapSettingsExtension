# Bootstrap Settings Extension
An extension to help you with bootstrapping your application.

['In general, bootstrapping usually refers to a self-starting process that is supposed to continue without external input.'](https://en.wikipedia.org/wiki/Bootstrapping) - Wikipedia.

Bootstrapping is modifying how your program runs from startup - usually based on a configuration file. 

## Table of Contents

- [Bootstrap Settings Extension](#bootstrap-settings-extension)
  - [Table of Contents](#table-of-contents)
  - [Dependencies](#dependencies)
  - [Using this Extension](#using-this-extension)
    - [Configuration](#configuration)
    - [Events](#events)
      - [RetrieveBootstrapSettingsEvent](#retrievebootstrapsettingsevent)
    - [Interfaces](#interfaces)

## Dependencies

This project is built upon TinYard at commit [#61477e8eecdc704454157b97574c40d8e1b501b5](https://github.com/TinYard/TinYard/commit/61477e8eecdc704454157b97574c40d8e1b501b5).

This is some way between Version 1.2 and Version 1.3. It should be updated to work with Version 1.3 when released.

## Using this Extension

Short and sweet:

* Inherit the `IBootstrapSettingRequestor` interface when you want to dispatch events asking for settings.
* Inherit the `IBootstrapSettingReceiver` interface when you want to receive settings requested.

### Configuration

This extension provides you with bootstrap settings from an XML file that you provide.

The location of this file can be set through the `BootstrapSettingsConfig`, as an override parameter - You need to provide an absolute path. 

Otherwise, the default location of your bootstrap file is `Directory.GetCurrentDirectory()/Assets/bootstrap-settings.xml` -> `WorkingDirectory/Assets/bootstrap-settings.xml`.

### Events

The Events available to use in this extension are:

* `RetrieveBootstrapSettingsEvent`

#### RetrieveBootstrapSettingsEvent

This event has two Type's:

* Get
* Got

When requesting a setting, use `Get`. You have two event constructors available for this:

```c-sharp
RetrieveBootstrapSettingsEvent(string settingName);

RetrieveBootstrapSettingsEvent(string settingName, Type settingType);
```

If you use the first constructor, it will default to getting a string value from the `IBootstrapSettingsModel` - The `SettingValue` will be a string.

The second constructor will return an `object`, but this should be of type `SettingValueType` and you should be able to successfully cast this.

When the value has been retrieved from the `IBootstrapSettingsModel`, the `Got` Type will be dispatched and you can listen for this.

### Interfaces

It is recommended that rather than create your own mediator to handle the events, as this requires adding more configurations, you use the `IBootstrapSettingRequestor` and/or `IBootstrapSettingReceiver` interfaces. The Requestor interface is for when you want to be able to dispatch the `Get` Type and the Receiver interface is for when receiving the `Got` Type. 