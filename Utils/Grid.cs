using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;
using Utils.Pagina.Attributes;
using Prova.Models;

namespace Prova.UtilsApi
{
    public class Grid
    {
        private static System.Xml.XmlNode FieldAttributes;
        public GridModel FillFormComponentFields(Type dataType, Boolean showCheckBox)
        {
            if (dataType.Name != "Base")
            {

                GridModel grid = new GridModel();

                String[] _fields = null;
                foreach (TClassAttributeFields fa in dataType.GetCustomAttributes(typeof(TClassAttributeFields), false))
                    _fields = fa.fields;

                if (_fields != null)
                {
                    String __fieldName = "";

                    foreach (String _fieldName in _fields)
                    {
                        if (_fieldName.StartsWith("."))
                        {
                            Type _objClass = dataType;
                            __fieldName = _fieldName;

                            while (__fieldName.StartsWith("."))
                            {
                                _objClass = _objClass.BaseType;
                                __fieldName = __fieldName.Substring(1);
                            }

                            System.Reflection.FieldInfo fi = _objClass.GetField
                            (
                                __fieldName,
                                (
                                    System.Reflection.BindingFlags.Instance |
                                    System.Reflection.BindingFlags.NonPublic |
                                    System.Reflection.BindingFlags.Public
                                )
                            );

                            Field _f = RetrieveFieldAttributes(fi);
                            grid.AddColumn(_f);
                            //this.createDataGridColumn
                            //(
                            //    Utils.RetrieveFieldAttributes(fi),
                            //    fi,
                            //    _objClass,
                            //    grid,
                            //    ref scriptBody,
                            //    ref onPopulateControls,
                            //    ref fieldsAttributes,
                            //    ref mensagemConfirmacao,
                            //    showCheckBox
                            //);
                        }
                        else
                        {
                            String[] fieldNameTokens = _fieldName.Split('.');

                            Type _dataType = dataType;

                            for (int i = 0; i < (fieldNameTokens.Length - 1); i++)
                            {
                                _dataType = _dataType.GetField
                                (
                                    fieldNameTokens[i],
                                    (
                                        System.Reflection.BindingFlags.Instance |
                                        System.Reflection.BindingFlags.NonPublic |
                                        System.Reflection.BindingFlags.Public
                                    )
                                ).FieldType;
                            }

                            System.Reflection.FieldInfo fi = _dataType.GetField
                            (
                                fieldNameTokens[fieldNameTokens.Length - 1],
                                (
                                    System.Reflection.BindingFlags.Instance |
                                    System.Reflection.BindingFlags.NonPublic |
                                    System.Reflection.BindingFlags.Public
                                )
                            );

                            Field _f = RetrieveFieldAttributes(fi);
                            grid.AddColumn(_f);
                            //this.createDataGridColumn
                            //(
                            //    Utils.RetrieveFieldAttributes(fi),
                            //    fi,
                            //    _dataType,
                            //    grid,
                            //    ref scriptBody,
                            //    ref onPopulateControls,
                            //    ref fieldsAttributes,
                            //    ref mensagemConfirmacao,
                            //    showCheckBox
                            //);
                        }
                    }
                }
                else
                {
                    foreach
                    (
                        System.Reflection.FieldInfo fi in
                        dataType.GetFields
                        (
                            System.Reflection.BindingFlags.Instance |
                            System.Reflection.BindingFlags.NonPublic |
                            System.Reflection.BindingFlags.Public
                        )
                    )
                    {
                        Field _f = RetrieveFieldAttributes(fi);
                        grid.AddColumn(_f);

                        //this.createDataGridColumn
                        //(
                        //    field,
                        //    fi,
                        //    dataType,
                        //    grid,
                        //    ref scriptBody,
                        //    ref onPopulateControls,
                        //    ref fieldsAttributes,
                        //    ref mensagemConfirmacao,
                        //    showCheckBox
                        //);
                    }

                    //this.FillFormComponentFields(dataType.BaseType, false);
                }

                if (showCheckBox)
                {
                    //{
                    //    this.createDataGridColumn
                    //    (
                    //        null,
                    //        null,
                    //        typeof(Boolean),
                    //        grid,
                    //        ref scriptBody,
                    //        ref onPopulateControls,
                    //        ref fieldsAttributes,
                    //        ref mensagemConfirmacao,
                    //        showCheckBox
                    //    );

                }
                else { }
                grid.key = String.Format("Grid_{0}_{1}", dataType.Name, Utils.Utils.RandomString(5, true));
                return grid;
            }
            else { }

            return null;
        }

        public static Field RetrieveFieldAttributes(System.Reflection.FieldInfo field, Type objClass = null, int? id = null)
        {
            Field result = null;

            if (field != null)
            {
                try
                {
                    String
                        fieldName = field.Name.Substring(2, 1).ToLower() + field.Name.Substring(3),
                        fieldGridDisplayText = "",
                        fieldEditDisplayText = "",
                        fieldSubFieldName = "",
                        fieldViewFormat = "",
                        fieldEditFormat = "",
                        fieldReportFilterName = "",
                        fieldReportFilterMask = "",
                        fieldReportFilterEntryFormat = "",
                        fieldReportFilterValueFormat = "",
                        fieldReportFilterValues = "",
                        fieldReportFilterWhereColumn = "";

                    int
                        fieldGridDisplaySize = 0,
                        fieldEditDisplaySize = 0,
                        fieldLength = 0,
                        fieldReportFieldSize = 0;

                    bool
                        fieldKey = false,
                        fieldRequired = false,
                        fieldEnabled = false,
                        fieldOboutDropBox = false,
                        fieldAutogenerated = false,
                        fieldReportAllowInterval = false,
                        fieldCargaParcial = false,
                        fielduseDecimalPlaces = true,
                        fieldShow = true;

                    if (objClass != null)
                    {

                        //System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                        //doc.Load(HttpContext.Current.Server.MapPath("~/relatoriosConfig/" + objClass.Name + ".xml"));
                        //FieldAttributes = doc.SelectSingleNode("/FieldAttributes");


                        String objClassName = objClass.Name;

                        if
                        (
                            (objClass != null) &&
                            (FieldAttributes[objClass.Name + (id != null ? ("_" + id.Value.ToString()) : "")] != null)
                        )
                            objClassName = objClass.Name + (id != null ? ("_" + id.Value.ToString()) : "");
                        else { }

                        if
                            (
                                (objClass != null) &&
                                (FieldAttributes[objClassName] != null) &&
                                (FieldAttributes[objClassName][field.Name] != null)
                            )
                        {

                            if (FieldAttributes[objClassName][field.Name].Attributes != null)
                            {
                                if (FieldAttributes[objClassName][field.Name].Attributes["label"] != null)
                                    fieldReportFilterName = FieldAttributes[objClassName][field.Name].Attributes["label"].Value;
                                else { }
                                if (FieldAttributes[objClassName][field.Name].Attributes["mask"] != null)
                                    fieldReportFilterMask = FieldAttributes[objClassName][field.Name].Attributes["mask"].Value;
                                else { }
                                if (FieldAttributes[objClassName][field.Name].Attributes["entryFormat"] != null)
                                    fieldReportFilterEntryFormat = FieldAttributes[objClassName][field.Name].Attributes["entryFormat"].Value;
                                else { }
                                if (FieldAttributes[objClassName][field.Name].Attributes["valueFormat"] != null)
                                    fieldReportFilterValueFormat = FieldAttributes[objClassName][field.Name].Attributes["valueFormat"].Value;
                                else { }
                                if (FieldAttributes[objClassName][field.Name].Attributes["size"] != null)
                                    fieldReportFieldSize = Utils.Utils.ToInt(FieldAttributes[objClassName][field.Name].Attributes["size"].Value);
                                else { }
                                if (FieldAttributes[objClassName][field.Name].Attributes["allowMultiValue"] != null)
                                    fieldReportAllowInterval = Utils.Utils.ToBoolean(FieldAttributes[objClassName][field.Name].Attributes["allowMultiValue"].Value);
                                else { }
                                if (FieldAttributes[objClassName][field.Name].Attributes["options"] != null)
                                    fieldReportFilterValues = FieldAttributes[objClassName][field.Name].Attributes["options"].Value;
                                else { }
                                if (FieldAttributes[objClassName][field.Name].Attributes["SQL"] != null)
                                {
                                    fieldReportFilterWhereColumn = FieldAttributes[objClassName][field.Name].Attributes["SQL"].Value;

                                    if (!fieldReportFilterWhereColumn.Contains("."))
                                        fieldReportFilterWhereColumn = objClass.Name.Substring(0, 1).ToLower() + objClass.Name.Substring(1) + "." + fieldReportFilterWhereColumn;
                                    else { }
                                }
                                else { }
                            }
                            else { }
                        }
                        else { }
                    }
                    else { }

                    foreach (Object fa in field.GetCustomAttributes(typeof(System.Attribute), false))
                    {
                        if (fa is TFieldAttributeData)
                        {
                            fieldLength = ((TFieldAttributeData)fa).length;
                            fieldRequired = ((TFieldAttributeData)fa).required;
                            fieldEnabled = ((TFieldAttributeData)fa).enabled;
                            fieldOboutDropBox = ((TFieldAttributeData)fa).oboutDropBox;
                        }
                        else
                        {
                            if (fa is TFieldAttributeGridDisplay)
                            {
                                fieldGridDisplayText = ((TFieldAttributeGridDisplay)fa).displayText;
                                fieldGridDisplaySize = ((TFieldAttributeGridDisplay)fa).displaySize;
                            }
                            else
                            {
                                if (fa is TFieldAttributeEditDisplay)
                                {
                                    fieldEditDisplayText = ((TFieldAttributeEditDisplay)fa).displayText;
                                    fieldEditDisplaySize = ((TFieldAttributeEditDisplay)fa).displaySize;
                                }
                                else
                                {
                                    if (fa is TFieldAttributeKey)
                                    {
                                        fieldKey = ((TFieldAttributeKey)fa).key;
                                        fieldAutogenerated = ((TFieldAttributeKey)fa).autogenerated;
                                    }
                                    else
                                    {
                                        if (fa is TFieldAttributeSubfield)
                                        {
                                            fieldSubFieldName = ((TFieldAttributeSubfield)fa).subFieldName;
                                            fieldCargaParcial = ((TFieldAttributeSubfield)fa).cargaParcial;

                                            if
                                            (
                                                (fieldSubFieldName.Length > 0) &&
                                                (
                                                    (!fieldSubFieldName.StartsWith("ItemGenerico")) &&
                                                    (!fieldSubFieldName.Contains(":@"))
                                                ) &&
                                                fieldName.ToLower().StartsWith("id")
                                            )
                                                fieldName = fieldName.Substring(2, 1).ToLower() + fieldName.Substring(3);
                                            else { }
                                        }
                                        else
                                        {
                                            if (fa is TFieldAttributeFormat)
                                            {
                                                fieldViewFormat = ((TFieldAttributeFormat)fa).viewFormat;
                                                fieldEditFormat = ((TFieldAttributeFormat)fa).editFormat;
                                                fielduseDecimalPlaces = ((TFieldAttributeFormat)fa).useDecimalPlaces;
                                                fieldShow = ((TFieldAttributeFormat)fa).showField;
                                            }
                                            else { }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    result = new Field
                    (
                        fieldKey,
                        fieldName,
                        fieldGridDisplayText,
                        fieldGridDisplaySize,
                        fieldEditDisplayText,
                        fieldEditDisplaySize,
                        fieldLength,
                        fieldRequired,
                        fieldEnabled,
                        fieldOboutDropBox,
                        fieldAutogenerated,
                        fieldSubFieldName,
                        fieldCargaParcial,
                        fieldViewFormat,
                        fieldEditFormat,
                        fielduseDecimalPlaces,
                        fieldShow,
                        fieldReportFilterName,
                        fieldReportFilterMask,
                        fieldReportFilterEntryFormat,
                        fieldReportFilterValueFormat,
                        fieldReportFieldSize,
                        fieldReportAllowInterval,
                        fieldReportFilterValues,
                        ((String.IsNullOrWhiteSpace(fieldReportFilterWhereColumn) && (objClass != null)) ? (objClass.Name.Substring(0, 1).ToLower() + objClass.Name.Substring(1) + "." + fieldName) : fieldReportFilterWhereColumn)
                    );
                }
                catch (Exception ex)
                {
                    Utils.Utils.WriteLog(ex.ToString());
                }
            }
            else { }

            return result;
        }

    }


    
}
