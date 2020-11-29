using System;
using System.Collections;

public class GlobalVariable
{
    //******************************************************************
    //*Hashtable用于存放全局变量，由key和value成对实现。
    //******************************************************************
    private static Hashtable table = new Hashtable();

    //******************************************************************
    //*由于是私有构造函数，不能由new产生实例，所以只有一个实例，
    //*保证了该类在程序中是唯一的。  
    //******************************************************************
    private GlobalVariable()
    {
    }

    public static object GetValue(object akey)
    {
        return table[akey];
    }
    public static void SetValue(object akey, object avalue)
    {
        table[akey] = avalue;
    }
    public static void Remove(object akey)
    {
        table.Remove(akey);
    }
}
