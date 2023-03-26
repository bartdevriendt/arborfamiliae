# Arbor Familiae

## Migrations

### MySql

dotnet ef migrations add "..." --project ./ArborFamiliae.Data.MySql --startup-project ./ArborFamiliae.Web

### Sqlite

dotnet ef migrations add "..." --project ./ArborFamiliae.Data.Sqlite --startup-project ./ArborFamiliae.Web -- --provider Sqlite



