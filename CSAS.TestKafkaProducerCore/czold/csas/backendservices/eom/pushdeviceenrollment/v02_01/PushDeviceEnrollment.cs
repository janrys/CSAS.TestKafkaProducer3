// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.10.0.0
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace cz.csas.backendservices.eom.pushdeviceenrollment.v02_01
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using Avro;
	using Avro.Specific;
	
	/// <summary>
	/// Message representing mobile device registration for given application to enable sending push messages from EOM.
	/// </summary>
	public partial class PushDeviceEnrollment : ISpecificRecord
	{
		public static Schema _SCHEMA = Avro.Schema.Parse("{\"type\":\"record\",\"name\":\"PushDeviceEnrollment\",\"namespace\":\"cz.csas.backendservic" +
				"es.eom.pushdeviceenrollment.v02_01\",\"fields\":[{\"name\":\"additionalInfo\",\"doc\":\"Ad" +
				"ditional informations helpful for audit (device type, etc.). Optional.\",\"default" +
				"\":null,\"type\":[\"null\",\"string\"]},{\"name\":\"applicationId\",\"doc\":\"Name of the mobi" +
				"le application according to RDS codetable CB_ApplicationSystem. E.g. GEORGE_GO\"," +
				"\"type\":\"string\"},{\"name\":\"username\",\"doc\":\"Non-cluid identification of the clien" +
				"t. Only back-up field usable after explicit analysis with EOM. One of cluid or u" +
				"sername must be provided.\",\"default\":null,\"type\":[\"null\",\"string\"]},{\"name\":\"clu" +
				"id\",\"doc\":\"CLUID identification of the client. CLUID should be provided. One of " +
				"cluid or clientId must be provided.\",\"default\":null,\"type\":[\"null\",\"string\"]},{\"" +
				"name\":\"deviceId\",\"doc\":\"Device token for android, certificate for IOs. In BASE64" +
				".\",\"type\":\"string\"},{\"name\":\"language\",\"doc\":\"Language for push notifications.\"," +
				"\"type\":\"string\"},{\"name\":\"enrollmentType\",\"doc\":\"Type of enrollment - POST means" +
				" registration, DELETE means unregistration.\",\"type\":{\"type\":\"enum\",\"name\":\"Enrol" +
				"lmentType\",\"namespace\":\"cz.csas.backendservices.eom.pushdeviceenrollment.v02_01\"" +
				",\"symbols\":[\"DELETE\",\"POST\"]}},{\"name\":\"operatingSystem\",\"doc\":\"Identification o" +
				"f device operating system. Use UNKNOWN only for DELETE enrollmentType.\",\"type\":{" +
				"\"type\":\"enum\",\"name\":\"OperatingSystem\",\"namespace\":\"cz.csas.backendservices.eom." +
				"pushdeviceenrollment.v02_01\",\"symbols\":[\"ANDROID\",\"IOS\",\"HARMONY\",\"UNKNOWN\"]}},{" +
				"\"name\":\"registrationTime\",\"doc\":\"Timestamp in millis of device registration.\",\"t" +
				"ype\":\"long\"},{\"name\":\"source\",\"doc\":\"Identification of the system, sending this " +
				"device registration. Value according to MW clients list. E.g. 204 for MCS. Neces" +
				"sary for audit.\",\"type\":\"string\"},{\"name\":\"deviceName\",\"doc\":\"Name of user devic" +
				"e. Used by requesting system to send push notification to the specific device of" +
				" the user.\",\"default\":null,\"type\":[\"null\",\"string\"]}]}");
		/// <summary>
		/// Additional informations helpful for audit (device type, etc.). Optional.
		/// </summary>
		private string _additionalInfo;
		/// <summary>
		/// Name of the mobile application according to RDS codetable CB_ApplicationSystem. E.g. GEORGE_GO
		/// </summary>
		private string _applicationId;
		/// <summary>
		/// Non-cluid identification of the client. Only back-up field usable after explicit analysis with EOM. One of cluid or username must be provided.
		/// </summary>
		private string _username;
		/// <summary>
		/// CLUID identification of the client. CLUID should be provided. One of cluid or clientId must be provided.
		/// </summary>
		private string _cluid;
		/// <summary>
		/// Device token for android, certificate for IOs. In BASE64.
		/// </summary>
		private string _deviceId;
		/// <summary>
		/// Language for push notifications.
		/// </summary>
		private string _language;
		/// <summary>
		/// Type of enrollment - POST means registration, DELETE means unregistration.
		/// </summary>
		private cz.csas.backendservices.eom.pushdeviceenrollment.v02_01.EnrollmentType _enrollmentType;
		/// <summary>
		/// Identification of device operating system. Use UNKNOWN only for DELETE enrollmentType.
		/// </summary>
		private cz.csas.backendservices.eom.pushdeviceenrollment.v02_01.OperatingSystem _operatingSystem;
		/// <summary>
		/// Timestamp in millis of device registration.
		/// </summary>
		private long _registrationTime;
		/// <summary>
		/// Identification of the system, sending this device registration. Value according to MW clients list. E.g. 204 for MCS. Necessary for audit.
		/// </summary>
		private string _source;
		/// <summary>
		/// Name of user device. Used by requesting system to send push notification to the specific device of the user.
		/// </summary>
		private string _deviceName;
		public virtual Schema Schema
		{
			get
			{
				return PushDeviceEnrollment._SCHEMA;
			}
		}
		/// <summary>
		/// Additional informations helpful for audit (device type, etc.). Optional.
		/// </summary>
		public string additionalInfo
		{
			get
			{
				return this._additionalInfo;
			}
			set
			{
				this._additionalInfo = value;
			}
		}
		/// <summary>
		/// Name of the mobile application according to RDS codetable CB_ApplicationSystem. E.g. GEORGE_GO
		/// </summary>
		public string applicationId
		{
			get
			{
				return this._applicationId;
			}
			set
			{
				this._applicationId = value;
			}
		}
		/// <summary>
		/// Non-cluid identification of the client. Only back-up field usable after explicit analysis with EOM. One of cluid or username must be provided.
		/// </summary>
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				this._username = value;
			}
		}
		/// <summary>
		/// CLUID identification of the client. CLUID should be provided. One of cluid or clientId must be provided.
		/// </summary>
		public string cluid
		{
			get
			{
				return this._cluid;
			}
			set
			{
				this._cluid = value;
			}
		}
		/// <summary>
		/// Device token for android, certificate for IOs. In BASE64.
		/// </summary>
		public string deviceId
		{
			get
			{
				return this._deviceId;
			}
			set
			{
				this._deviceId = value;
			}
		}
		/// <summary>
		/// Language for push notifications.
		/// </summary>
		public string language
		{
			get
			{
				return this._language;
			}
			set
			{
				this._language = value;
			}
		}
		/// <summary>
		/// Type of enrollment - POST means registration, DELETE means unregistration.
		/// </summary>
		public cz.csas.backendservices.eom.pushdeviceenrollment.v02_01.EnrollmentType enrollmentType
		{
			get
			{
				return this._enrollmentType;
			}
			set
			{
				this._enrollmentType = value;
			}
		}
		/// <summary>
		/// Identification of device operating system. Use UNKNOWN only for DELETE enrollmentType.
		/// </summary>
		public cz.csas.backendservices.eom.pushdeviceenrollment.v02_01.OperatingSystem operatingSystem
		{
			get
			{
				return this._operatingSystem;
			}
			set
			{
				this._operatingSystem = value;
			}
		}
		/// <summary>
		/// Timestamp in millis of device registration.
		/// </summary>
		public long registrationTime
		{
			get
			{
				return this._registrationTime;
			}
			set
			{
				this._registrationTime = value;
			}
		}
		/// <summary>
		/// Identification of the system, sending this device registration. Value according to MW clients list. E.g. 204 for MCS. Necessary for audit.
		/// </summary>
		public string source
		{
			get
			{
				return this._source;
			}
			set
			{
				this._source = value;
			}
		}
		/// <summary>
		/// Name of user device. Used by requesting system to send push notification to the specific device of the user.
		/// </summary>
		public string deviceName
		{
			get
			{
				return this._deviceName;
			}
			set
			{
				this._deviceName = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.additionalInfo;
			case 1: return this.applicationId;
			case 2: return this.username;
			case 3: return this.cluid;
			case 4: return this.deviceId;
			case 5: return this.language;
			case 6: return this.enrollmentType;
			case 7: return this.operatingSystem;
			case 8: return this.registrationTime;
			case 9: return this.source;
			case 10: return this.deviceName;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.additionalInfo = (System.String)fieldValue; break;
			case 1: this.applicationId = (System.String)fieldValue; break;
			case 2: this.username = (System.String)fieldValue; break;
			case 3: this.cluid = (System.String)fieldValue; break;
			case 4: this.deviceId = (System.String)fieldValue; break;
			case 5: this.language = (System.String)fieldValue; break;
			case 6: this.enrollmentType = (cz.csas.backendservices.eom.pushdeviceenrollment.v02_01.EnrollmentType)fieldValue; break;
			case 7: this.operatingSystem = (cz.csas.backendservices.eom.pushdeviceenrollment.v02_01.OperatingSystem)fieldValue; break;
			case 8: this.registrationTime = (System.Int64)fieldValue; break;
			case 9: this.source = (System.String)fieldValue; break;
			case 10: this.deviceName = (System.String)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}
