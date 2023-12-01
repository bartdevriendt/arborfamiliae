using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArborFamiliae.ViewModels.Base;
using DevExpress.Mvvm.CodeGenerators;

namespace ArborFamiliae.ViewModels.Database
{
    [GenerateViewModel]
    public partial class NewDatabaseViewModel : ArborViewModelBase
    {
        [GenerateProperty] private string _databaseName = string.Empty;
        [GenerateProperty] private string _databaseType = string.Empty;
        [GenerateProperty] private string _server = string.Empty;
        [GenerateProperty] private string _username = string.Empty;
        [GenerateProperty] private string _password = string.Empty;
        [GenerateProperty] private string _family = string.Empty;


    }
}
