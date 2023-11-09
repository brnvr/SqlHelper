using System;
using System.Collections.Generic;
using System.Text;

namespace SqlHelper
{
    public interface ISqlConvertible
    {
        string ToSql();
    }
}
