// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.7.7.5
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace cz.csas.avroschemas.administeredpayment_processpayment.v03_01
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using global::Avro;
	using global::Avro.Specific;
	
	public partial class ExternalLiability : ISpecificRecord
	{
		public static Schema _SCHEMA = Schema.Parse("{\"type\":\"record\",\"name\":\"ExternalLiability\",\"namespace\":\"cz.csas.avroschemas.admi" +
				"nisteredpayment_processpayment.v03_01\",\"fields\":[{\"name\":\"externalLiabilityId\",\"" +
				"doc\":\"Externi id zavazku\",\"type\":\"string\"}]}");
		/// <summary>
		/// Externi id zavazku
		/// </summary>
		private string _externalLiabilityId;
		public virtual Schema Schema
		{
			get
			{
				return ExternalLiability._SCHEMA;
			}
		}
		/// <summary>
		/// Externi id zavazku
		/// </summary>
		public string externalLiabilityId
		{
			get
			{
				return this._externalLiabilityId;
			}
			set
			{
				this._externalLiabilityId = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.externalLiabilityId;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.externalLiabilityId = (System.String)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}
