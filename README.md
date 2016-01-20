# Configuration.ValuesHelper
## Description

A library which provides methods to retrieve app settings as various datatypes.

## Usage
1. Add Nuget package to your project (https://www.nuget.org/packages/Configuration.ValuesHelper/)
2. Insert 'Using Configuration.ValuesHelper;' at the top of any files you wish to use it on.
3. Call class ConfigValue.METHODNAME.

## Available Functions
#### string GetAsString(string key)

#### bool GetAsBool(string key)

#### bool? GetAsNullableBool(string key)

#### int GetAsInt(string key)

#### int? GetAsNullableInt(string key)

#### double GetAsDouble(string key)

#### double? GetAsNullableDouble(string key)

#### DateTime GetAsDateTime(string key)

#### DateTime? GetAsNullableDateTime(string key)
