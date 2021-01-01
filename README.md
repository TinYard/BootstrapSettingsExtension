# Bootstrap Settings Extension
An extension to help you with bootstrapping your application.

['In general, bootstrapping usually refers to a self-starting process that is supposed to continue without external input.'](https://en.wikipedia.org/wiki/Bootstrapping) - Wikipedia.

Bootstrapping is modifying how your program runs from startup - usually based on a configuration file. 

## Table of Contents

- [Bootstrap Settings Extension](#bootstrap-settings-extension)
  - [Table of Contents](#table-of-contents)
  - [Dependencies](#dependencies)
  - [Using this Extension](#using-this-extension)

## Dependencies

This project is built upon TinYard at commit [#9edabcdc237cdf787048b37308707e268eb32146](https://github.com/TinYard/TinYard/commit/9edabcdc237cdf787048b37308707e268eb32146).

This is some way between Version 1.2 and Version 1.3. It should be updated to work with Version 1.3 when released.

## Using this Extension

This extension provides you with bootstrap settings from an XML file that you provide.

The location of this file can be set through the `BootstrapSettingsConfig`, as an override parameter. 

The default location of your bootstrap file is `Directory.GetCurrentDirectory()/Assets/Bootstraps.xml` -> `WorkingDirectory/Assets/Bootstraps.xml`.