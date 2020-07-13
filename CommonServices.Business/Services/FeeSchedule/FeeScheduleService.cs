using CommonServices.Business.Entities.FeeSchedule;
using CommonServices.Business.Entities.Common;
using CommonServices.Business.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServices.Business.Services.FeeSchedule
{
    public class FeeScheduleService
    {
        public FeeScheduleData GetFeeSchedule(FeeScheduleParameter parameters)
        {
            FeeScheduleData feeSchedule = new FeeScheduleData();
            using (SqlConnection oConnection = new SqlConnection(DBUtilities.ConnectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = new SqlCommand(ApplicationConstants.FEESCHEDULE_GETFEESCHEDULE, oConnection))
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandTimeout = 0;
                    oCommand.Parameters.AddWithValue("@CPTCode", parameters.CPTCode);
                    oCommand.Parameters.AddWithValue("@BillingSpecialty", parameters.BillingSpecialty);
                    oCommand.Parameters.AddWithValue("@DoctorSpecialty", parameters.DoctorSpecialty);
                    oCommand.Parameters.AddWithValue("@State", parameters.State);
                    oCommand.Parameters.AddWithValue("@Region", parameters.Region);
                    oCommand.Parameters.AddWithValue("@DateOfService", parameters.DateOfService);

                    SqlDataReader reader = oCommand.ExecuteReader();

                    if (reader.Read())
                    {
                        feeSchedule.CPTCode = Convert.ToString(reader["CPTCode"]);
                        feeSchedule.BillingSpecialty = Convert.ToString(reader["BillingSpecialty"]);
                        feeSchedule.DoctorSpecialty = Convert.ToString(reader["DoctorSpecialty"]);
                        feeSchedule.State = Convert.ToString(reader["State"]);
                        feeSchedule.Region = Convert.ToString(reader["Region"]);
                        feeSchedule.BasicUnit = Convert.ToDecimal(reader["BasicUnit"]);
                        feeSchedule.Conversionfator = Convert.ToDecimal(reader["Conversionfator"]);
                        feeSchedule.EffectiveFromDate = Convert.ToDateTime(reader["EffectiveFromDate"]);
                        feeSchedule.EffectiveToDate = Convert.ToDateTime(reader["EffectiveToDate"]);
                    }
                }
            }
            return feeSchedule;
        }

        public void AddFeeSchedule(FeeScheduleData parameters)
        {
            using (SqlConnection oConnection = new SqlConnection(DBUtilities.ConnectionString))
            {
                oConnection.Open();
                using (SqlCommand oCommand = new SqlCommand(ApplicationConstants.FEESCHEDULE_ADDFEESCHEDULE, oConnection))
                {
                    oCommand.CommandType = CommandType.StoredProcedure;
                    oCommand.CommandTimeout = 0;
                    oCommand.Parameters.AddWithValue("@CPTCode", parameters.CPTCode);
                    oCommand.Parameters.AddWithValue("@BillingSpecialty", parameters.BillingSpecialty);
                    oCommand.Parameters.AddWithValue("@DoctorSpecialty", parameters.DoctorSpecialty);
                    oCommand.Parameters.AddWithValue("@State", parameters.State);
                    oCommand.Parameters.AddWithValue("@Region", parameters.Region);
                    oCommand.Parameters.AddWithValue("@BasicUnit", parameters.BasicUnit);
                    oCommand.Parameters.AddWithValue("@Conversionfator", parameters.Conversionfator);
                    oCommand.Parameters.AddWithValue("@EffectiveFromDate", parameters.EffectiveFromDate);
                    oCommand.Parameters.AddWithValue("@EffectiveToDate", parameters.EffectiveToDate);

                    oCommand.ExecuteNonQuery();
                }
            }
        }
    }
}

