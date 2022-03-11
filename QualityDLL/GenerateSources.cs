using System;
using System.Collections.Generic;
using System.Web;

public class GenerateSources
{

    public static void Generate(String ConnectionString)
    {
        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConnectionString);

        try
        {
            con.Open();

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand
            (
                "select name from sysobjects where type = 'u' and name <> 'dbTypes' order by name",
                con
            );

            System.Data.SqlClient.SqlDataReader drt = cmd.ExecuteReader();

            System.Collections.Generic.List<String> tables = new System.Collections.Generic.List<String>();

            while (drt.Read())
                tables.Add(drt.GetString(drt.GetOrdinal("name")));

            drt.Close();

            foreach (String t in tables)
            {
                String _t = "_" + t;
                int i = 0;
                while ((i = _t.IndexOf('_')) >= 0)
                    _t = (i > 0 ? _t.Substring(0, i) : "") + _t.Substring(i + 1, 1).ToUpper() + _t.Substring(i + 2);

                System.IO.StreamWriter f = null;

                //Bean
                f = System.IO.File.CreateText("C:\\temp\\Data\\" + _t + ".cs");

                cmd = new System.Data.SqlClient.SqlCommand
                (
                    "exec generateSourceCSharpBean '" + t + "'",
                    con
                );

                drt = cmd.ExecuteReader();

                while (drt.Read())
                    f.WriteLine(drt.GetString(drt.GetOrdinal("source")));

                drt.Close();

                f.Close();

                //Table
                f = System.IO.File.CreateText("C:\\temp\\Tables\\" + _t + ".cs");

                cmd = new System.Data.SqlClient.SqlCommand
                (
                    "exec generateSourceCSharp '" + t + "'",
                    con
                );

                drt = cmd.ExecuteReader();

                while (drt.Read())
                    f.WriteLine(drt.GetString(drt.GetOrdinal("source")));

                drt.Close();

                f.Close();

                //CRUD
                f = System.IO.File.CreateText("C:\\temp\\CRUD\\" + _t + ".cs");

                cmd = new System.Data.SqlClient.SqlCommand
                (
                    "exec generateSourceCSharpCRUD '" + t + "'",
                    con
                );

                drt = cmd.ExecuteReader();

                while (drt.Read())
                    f.WriteLine(drt.GetString(drt.GetOrdinal("source")));

                drt.Close();

                f.Close();
            }

            con.Close();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }

    public static void Generate(String ConnectionString, String TableName, bool Data = false, bool Table = false, bool CRUD = false)
    {
        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(ConnectionString);

        try
        {
            con.Open();

            System.Data.SqlClient.SqlCommand cmd = null;
            System.Data.SqlClient.SqlDataReader drt = null;

            String t = TableName;

            String _t = "_" + t;
            int i = 0;
            while ((i = _t.IndexOf('_')) >= 0)
                _t = (i > 0 ? _t.Substring(0, i) : "") + _t.Substring(i + 1, 1).ToUpper() + _t.Substring(i + 2);

            System.IO.StreamWriter f = null;

            if (Data)
            {
                //Bean
                f = System.IO.File.CreateText("C:\\temp\\Data\\" + _t + ".cs");

                cmd = new System.Data.SqlClient.SqlCommand
                (
                    "exec generateSourceCSharpBean '" + t + "'",
                    con
                );

                drt = cmd.ExecuteReader();

                while (drt.Read())
                    f.WriteLine(drt.GetString(drt.GetOrdinal("source")));

                drt.Close();

                f.Close();

            }
            else { }
            if (Table)
            {
                //Table
                f = System.IO.File.CreateText("C:\\temp\\Tables\\" + _t + ".cs");

                cmd = new System.Data.SqlClient.SqlCommand
                (
                    "exec generateSourceCSharp '" + t + "'",
                    con
                );

                drt = cmd.ExecuteReader();

                while (drt.Read())
                    f.WriteLine(drt.GetString(drt.GetOrdinal("source")));

                drt.Close();

                f.Close();
            }
            else { }

            if (CRUD)
            {
                //CRUD
                f = System.IO.File.CreateText("C:\\temp\\CRUD\\" + _t + ".cs");

                cmd = new System.Data.SqlClient.SqlCommand
                (
                    "exec generateSourceCSharpCRUD '" + t + "'",
                    con
                );

                drt = cmd.ExecuteReader();

                while (drt.Read())
                    f.WriteLine(drt.GetString(drt.GetOrdinal("source")));

                drt.Close();

                f.Close();
            }
            else { }

            con.Close();
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
}