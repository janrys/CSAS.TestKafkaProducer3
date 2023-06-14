// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.11.1
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
	
	[global::System.CodeDom.Compiler.GeneratedCodeAttribute("avrogen", "1.11.1")]
	public partial class PaymentReceiver : global::Avro.Specific.ISpecificRecord
	{
		public static global::Avro.Schema _SCHEMA = global::Avro.Schema.Parse("{\"type\":\"record\",\"name\":\"PaymentReceiver\",\"namespace\":\"cz.csas.avroschemas.admini" +
				"steredpayment_processpayment.v03_01\",\"fields\":[{\"name\":\"idCard\",\"default\":null,\"" +
				"type\":[\"null\",{\"type\":\"record\",\"name\":\"IdCard\",\"namespace\":\"cz.csas.avroschemas." +
				"administeredpayment_processpayment.v03_01\",\"fields\":[{\"name\":\"cardNumber\",\"doc\":" +
				"\"cislo dokladu\",\"default\":null,\"type\":[\"null\",\"string\"]},{\"name\":\"cardType\",\"doc" +
				"\":\"typ ID dokladu (OP, cestovni pas, ridicsky prukaz...)\",\"default\":null,\"type\":" +
				"[\"null\",\"string\"]},{\"name\":\"issuer\",\"doc\":\"Udava kdo doklad vydal (urad).\",\"defa" +
				"ult\":null,\"type\":[\"null\",\"string\"]},{\"name\":\"issuerCountry\",\"doc\":\"(doklad) vyda" +
				"l stat\",\"default\":null,\"type\":[\"null\",\"string\"]},{\"name\":\"validUntil\",\"default\":" +
				"null,\"type\":[\"null\",{\"type\":\"int\",\"logicalType\":\"date\"}]}]}]},{\"name\":\"liability" +
				"PaymentRoleType\",\"type\":\"string\"},{\"name\":\"permanentAddress\",\"default\":null,\"typ" +
				"e\":[\"null\",{\"type\":\"record\",\"name\":\"PermanentAddress\",\"namespace\":\"cz.csas.avros" +
				"chemas.administeredpayment_processpayment.v03_01\",\"fields\":[{\"name\":\"l1_recipien" +
				"t\",\"doc\":\"Adresni radek 1 Prijmeni, Jmeno, Titul pred, Titul za\\r\\n\\r\\nPouziti f" +
				"ormatovane adresy je popsano primo v entite PostalAddress.\",\"default\":null,\"type" +
				"\":[\"null\",\"string\"]},{\"name\":\"l2_supplement\",\"doc\":\"Adresni radek 2, Doplnek\\r\\n" +
				"\\r\\nPouziti formatovane adresy je popsano primo v entite PostalAddress.\",\"defaul" +
				"t\":null,\"type\":[\"null\",\"string\"]},{\"name\":\"l3_street\",\"doc\":\"Adresni radek 3, Ul" +
				"ice (nebo Cast obce, kdyz je pole Ulice prazdne), „Cislo popisne/orientacni“ neb" +
				"o „Cislo evidencni\\r\\n\\r\\nPouziti formatovane adresy je popsano primo v entite P" +
				"ostalAddress.\",\"default\":null,\"type\":[\"null\",\"string\"]},{\"name\":\"l4_city\",\"doc\":" +
				"\"Adresni radek 4, Obec/Cast Obce\\r\\n\\r\\nPouziti formatovane adresy je popsano pr" +
				"imo v entite PostalAddress.\",\"default\":null,\"type\":[\"null\",\"string\"]},{\"name\":\"l" +
				"5_zipcode\",\"doc\":\"Adresni radek 5, PSC, Posta\\r\\n\\r\\nPouziti formatovane adresy " +
				"je popsano primo v entite PostalAddress.\",\"default\":null,\"type\":[\"null\",\"string\"" +
				"]},{\"name\":\"l6_country\",\"doc\":\"Adresni radek 6, Stat. Pokud je to CR, pole se ne" +
				"vraci.\\r\\n\\r\\nPouziti formatovane adresy je popsano primo v entite PostalAddress" +
				".\",\"default\":null,\"type\":[\"null\",\"string\"]}]}]},{\"name\":\"person\",\"type\":{\"type\":" +
				"\"record\",\"name\":\"Person\",\"namespace\":\"cz.csas.avroschemas.administeredpayment_pr" +
				"ocesspayment.v03_01\",\"fields\":[{\"name\":\"additionalDegree\",\"doc\":\"Additional acad" +
				"emic degree. (Titul za jmenem.)\",\"default\":null,\"type\":[\"null\",\"string\"]},{\"name" +
				"\":\"birthCountry\",\"doc\":\"zeme narozeni\",\"default\":null,\"type\":[\"null\",\"string\"]}," +
				"{\"name\":\"birthPlace\",\"doc\":\"misto (mesto) narozeni\",\"default\":null,\"type\":[\"null" +
				"\",\"string\"]},{\"name\":\"citizenships\",\"default\":null,\"type\":[\"null\",{\"type\":\"array" +
				"\",\"items\":{\"type\":\"record\",\"name\":\"Citizenship\",\"namespace\":\"cz.csas.avroschemas" +
				".administeredpayment_processpayment.v03_01\",\"fields\":[{\"name\":\"citizenship\",\"doc" +
				"\":\"statni prislusnost / obcanstvi\",\"type\":\"string\"}]}}]},{\"name\":\"degree\",\"doc\":" +
				"\"Academic degree. (titul pred)\",\"default\":null,\"type\":[\"null\",\"string\"]},{\"name\"" +
				":\"email\",\"doc\":\"emailova adresa\",\"default\":null,\"type\":[\"null\",\"string\"]},{\"name" +
				"\":\"forename\",\"doc\":\"(krestni) jmeno\",\"type\":\"string\"},{\"name\":\"gender\",\"doc\":\"po" +
				"hlavi\",\"default\":null,\"type\":[\"null\",\"string\"]},{\"name\":\"personalId\",\"doc\":\"Pro " +
				"ceske obcany to je rodne cislo. Pro cizince cislo odvozene od datumu narozani (j" +
				"ak rc) a posledne 4 cislice jsou devitky. Proto cizinci narozeni v jednom dni je" +
				" maji rovnake.\",\"type\":\"string\"},{\"name\":\"surname\",\"doc\":\"prijmeni\",\"type\":\"stri" +
				"ng\"},{\"name\":\"taxResidency\",\"default\":null,\"type\":[\"null\",\"string\"]}]}},{\"name\":" +
				"\"verified\",\"type\":\"boolean\"}]}");
		private cz.csas.avroschemas.administeredpayment_processpayment.v03_01.IdCard _idCard;
		private string _liabilityPaymentRoleType;
		private cz.csas.avroschemas.administeredpayment_processpayment.v03_01.PermanentAddress _permanentAddress;
		private cz.csas.avroschemas.administeredpayment_processpayment.v03_01.Person _person;
		private bool _verified;
		public virtual global::Avro.Schema Schema
		{
			get
			{
				return PaymentReceiver._SCHEMA;
			}
		}
		public cz.csas.avroschemas.administeredpayment_processpayment.v03_01.IdCard idCard
		{
			get
			{
				return this._idCard;
			}
			set
			{
				this._idCard = value;
			}
		}
		public string liabilityPaymentRoleType
		{
			get
			{
				return this._liabilityPaymentRoleType;
			}
			set
			{
				this._liabilityPaymentRoleType = value;
			}
		}
		public cz.csas.avroschemas.administeredpayment_processpayment.v03_01.PermanentAddress permanentAddress
		{
			get
			{
				return this._permanentAddress;
			}
			set
			{
				this._permanentAddress = value;
			}
		}
		public cz.csas.avroschemas.administeredpayment_processpayment.v03_01.Person person
		{
			get
			{
				return this._person;
			}
			set
			{
				this._person = value;
			}
		}
		public bool verified
		{
			get
			{
				return this._verified;
			}
			set
			{
				this._verified = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.idCard;
			case 1: return this.liabilityPaymentRoleType;
			case 2: return this.permanentAddress;
			case 3: return this.person;
			case 4: return this.verified;
			default: throw new global::Avro.AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.idCard = (cz.csas.avroschemas.administeredpayment_processpayment.v03_01.IdCard)fieldValue; break;
			case 1: this.liabilityPaymentRoleType = (System.String)fieldValue; break;
			case 2: this.permanentAddress = (cz.csas.avroschemas.administeredpayment_processpayment.v03_01.PermanentAddress)fieldValue; break;
			case 3: this.person = (cz.csas.avroschemas.administeredpayment_processpayment.v03_01.Person)fieldValue; break;
			case 4: this.verified = (System.Boolean)fieldValue; break;
			default: throw new global::Avro.AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}