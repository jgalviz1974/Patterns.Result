# Changelog - Gasolutions.Core.Patterns.Result

All notable changes to this project will be documented in this file.


## [2.0.0.0]
### Added
- `ErrorLanguage` static class to configure the active culture for error messages (defaults to Spanish `es`)
- `ErrorMessages` internal helper that resolves localized message templates via `ResourceManager`
- `Messages.resx` embedded resource with 38 Spanish message templates (default language)
- `Messages.en.resx` embedded resource with 38 English message templates
- Bilingual support (Spanish / English) across all error factories: `ArgumentErrors`, `AuthErrors`, `AzureStorageErrors`, `CommunicationErrors`, `ContainerErrors`, `DatabaseErrors`, `EmailErrors`, `EnviromentVariableErrors`, `HttpErrors`, `KeyValueErrors`, `OtherErrors`, `TokenErrors`, `TwoFactorErrors`

### Changed
- All fixed error message strings in error factories replaced with `ErrorMessages.Get(key, args)` resource lookups
- Caller-supplied messages (`OtherErrors.NotDefined`, `AuthErrors.RequiredField`, `EmailErrors.Others`, `HttpErrors.InternalServerError`, `HttpErrors.General`, `ExceptionErrors.*`) remain unchanged — they are not localized by the library
- `Error.Create(...)` centralizes `StackTraceHelper.RetrieveCallerInfo()` — no longer called directly from factory classes
- `StackTraceHelper.RetrieveCallerInfo(int frameOffset = 0)` now accepts a frame offset to compensate for wrapper calls


## [1.0.10.1]
### Added
- Add KeyValue errors 
- Add Email errors

## [1.0.10.0]
### Added
- Add Autentications errors 
- Add Azure Storage errors
- Add Enviroment errors
- Add HTTP errors

### Changed
- StackTraceHelper is public now


## [1.0.9.0]
### Added
- Add CassName and Method Name for better error context
- New error code generation strategy using StackTraceHelper for more accurate error tracking

## [1.0.8.1]
### Added
- Add NotFound method for string field in DatabaseErrors

## [1.0.8]
### Added	
- Add CHANGELOG.md file to document changes and updates

## [1.0.7]

### Added
- Comprehensive XML documentation for all error factories
- Automatic error code generation using StackTraceHelper
- Support for multiple error types with builder patterns
- Complete test suites for ArgumentErrors, CommunicationErrors, DatabaseErrors, ExceptionErrors, and OtherErrors
- Enhanced exception context preservation
- Detailed error reporting with exception hierarchy support

### Changed
- Improved StackTraceInfo encapsulation with private properties
- Enhanced error messages with better formatting
- Updated documentation to English for international audience
- Refactored error factories for consistency

### Fixed
- Error code generation accuracy
- Null reference handling in error creation
- Exception context tracking improvements

### Documentation
- Added comprehensive XML documentation for all error factories
- Created test suite documentation with 50+ test cases
- Updated inline code comments in English

---

## [1.0.6]

### Initial Release
- Basic Result pattern implementation
- Generic Result<T> class
- Non-generic Result class
- Error handling with Error record
- ArgumentErrors factory for validation errors
- DatabaseErrors factory for data access errors
- CommunicationErrors factory for service communication errors
- ExceptionErrors factory for exception handling
- OtherErrors factory for undefined scenarios
