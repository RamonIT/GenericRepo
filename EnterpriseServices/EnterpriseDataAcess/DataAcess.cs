using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Data;

namespace EnterpriseDataAcess
{
    public class DataAcess<E> where E : new()
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cn"].ToString());

        public List<E> GetAll(string command)
        {
            SqlCommand cmd = new SqlCommand(command, cn);
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<E> entities = new List<E>();

            while (reader.Read())
            {
                entities.Add(MappingRow(reader));
            }

            cn.Close();
            return entities;
        }

        private E MappingRow(IDataReader reader)
        {
            E item = new E();

            var typeProperties = typeof(E).GetProperties();

            foreach (var property in typeProperties)
            {
                int ordinal = reader.GetOrdinal(property.Name);

                if (!reader.IsDBNull(ordinal))
                {
                    property.SetValue(item, getValueByTypeDBColumn<IConvertible>(reader, ordinal, property.PropertyType), null);
                }
            }

            return item;
        }

        private T getValueByTypeDBColumn<T>(IDataReader reader, int ordinal, Type targetType) where T : IConvertible
        {
            T t = default(T);
            Type PropertyInfo = reader.GetFieldType(ordinal);

            switch (PropertyInfo.ToString())   
            {
                case ("System.String"):
                    t = (T)Convert.ChangeType(reader.GetString(ordinal), targetType);
                    break;
                case ("System.Int32"):
                    t = (T)Convert.ChangeType(reader.GetInt32(ordinal), targetType);
                    break;
                case ("System.Decimal"):
                    t = (T)Convert.ChangeType(reader.GetDecimal(ordinal), targetType);
                    break;
                default:
                    break;
            }

            return t;
        }

    }
}
