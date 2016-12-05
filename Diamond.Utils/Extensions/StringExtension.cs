using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StringExtension
{
    public static string GetFileExtension(this string file)
    {
        var ext = file.Substring(file.LastIndexOf('.'));
        return ext.ToLower();
    }
}