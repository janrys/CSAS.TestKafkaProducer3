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
	
	public partial class IdCard : ISpecificRecord
	{
		public static Schema _SCHEMA = Schema.Parse(@"{""type"":""record"",""name"":""IdCard"",""namespace"":""cz.csas.avroschemas.administeredpayment_processpayment.v03_01"",""fields"":[{""name"":""cardNumber"",""doc"":""cislo dokladu"",""default"":null,""type"":[""null"",""string""]},{""name"":""cardType"",""doc"":""typ ID dokladu (OP, cestovni pas, ridicsky prukaz...)"",""default"":null,""type"":[""null"",""string""]},{""name"":""issuer"",""doc"":""Udava kdo doklad vydal (urad)."",""default"":null,""type"":[""null"",""string""]},{""name"":""issuerCountry"",""doc"":""(doklad) vydal stat"",""default"":null,""type"":[""null"",""string""]},{""name"":""validUntil"",""default"":null,""type"":[""null"",""int""]}]}");
		/// <summary>
		/// cislo dokladu
		/// </summary>
		private string _cardNumber;
		/// <summary>
		/// typ ID dokladu (OP, cestovni pas, ridicsky prukaz...)
		/// </summary>
		private string _cardType;
		/// <summary>
		/// Udava kdo doklad vydal (urad).
		/// </summary>
		private string _issuer;
		/// <summary>
		/// (doklad) vydal stat
		/// </summary>
		private string _issuerCountry;
		private System.Nullable<int> _validUntil;
		public virtual Schema Schema
		{
			get
			{
				return IdCard._SCHEMA;
			}
		}
		/// <summary>
		/// cislo dokladu
		/// </summary>
		public string cardNumber
		{
			get
			{
				return this._cardNumber;
			}
			set
			{
				this._cardNumber = value;
			}
		}
		/// <summary>
		/// typ ID dokladu (OP, cestovni pas, ridicsky prukaz...)
		/// </summary>
		public string cardType
		{
			get
			{
				return this._cardType;
			}
			set
			{
				this._cardType = value;
			}
		}
		/// <summary>
		/// Udava kdo doklad vydal (urad).
		/// </summary>
		public string issuer
		{
			get
			{
				return this._issuer;
			}
			set
			{
				this._issuer = value;
			}
		}
		/// <summary>
		/// (doklad) vydal stat
		/// </summary>
		public string issuerCountry
		{
			get
			{
				return this._issuerCountry;
			}
			set
			{
				this._issuerCountry = value;
			}
		}
		public System.Nullable<int> validUntil
		{
			get
			{
				return this._validUntil;
			}
			set
			{
				this._validUntil = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.cardNumber;
			case 1: return this.cardType;
			case 2: return this.issuer;
			case 3: return this.issuerCountry;
			case 4: return this.validUntil;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.cardNumber = (System.String)fieldValue; break;
			case 1: this.cardType = (System.String)fieldValue; break;
			case 2: this.issuer = (System.String)fieldValue; break;
			case 3: this.issuerCountry = (System.String)fieldValue; break;
			case 4: this.validUntil = (System.Nullable<int>)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}