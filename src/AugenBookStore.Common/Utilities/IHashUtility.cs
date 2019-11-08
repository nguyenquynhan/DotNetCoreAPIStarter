using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreTodoApi.Common.Utilities
{
    public interface IHashUtility
    {
        string Encrypt(string text);
    }
}
