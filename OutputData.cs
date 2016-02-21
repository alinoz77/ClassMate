using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;


namespace ClassMate.Output
{
    public class OutputData
    {
    public string Name,DOB;
    public double Value;
    public string ReadDate;
    
    public OutputData(string name, string dob, double attention, string readdate)
    {
        Name = name;
        DOB = dob;
        Value = attention;
        ReadDate = readdate;
        
    }
    }}