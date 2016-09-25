using System;
namespace Motion.Mobile.Utilities
{
	public class Constants
	{
		public const int INT32_BYTE_SIZE = 4;
		public const int UINT16_BYTE_SIZE = 2;
		public const int CHAR_BYTE_SIZE = 1;
		public const int TOTAL_SEIZURE_BLOCKS_PER_RECORD = 32;

		public const int INDEX_ZERO = 0;
		public const int PACKET_BYTE_SIZE = 20;

		private static volatile Constants instance = new Constants();
		private static object syncRoot = new object();

		public static Constants Instance
		{
			get
			{
				if (instance == null)
				{
					lock (syncRoot)
					{
						if (instance == null)
							instance = new Constants();
					}
				}
				return instance;
			}
		}

		//Devices Brand-model
		public enum TrioDeviceModel
		{
			PE932 = 932,
			PE936 = 936,
			PE939 = 939,
			PE961 = 961,
			FT900 = 900,
			FT905 = 905,
			FT965 = 965,
			FT969 = 969
		}


		//BLE Services
		public enum ServicesUUID
		{
			_FF01, //Trio Custom Service
			_180A, //Device Information
			_180F, //Battery Level
			_1530, //DFU Service

			_67FE, //Striiv GCP
		}

		//BLE Characteristics
		public enum CharacteristicsUUID
		{
			//[Trio Custom Service]
			_FF07, //FF07 Read,Indicate/Notify
			_FF08, //FF08 Read, Indicate/Notify

			//[Device Information]
			_2A29, //Manufacturer
			_2A24, //Model
			_2A25, //Serial
			_2A26, //Firmware Version

			//[Battery Service]
			_2A19, //Battery Level

			//[Striiv]
			_FE23, //TX (Notify)
			_9A0A  //RX (Write, Write w/o response
		}


		//SyncHandler Sequence Names
		public enum SyncHandlerSequence
		{
			Default,
			EnableFF07,
			EnableFF08,
			ReadSerial,
			ReadModel,
			ReadFwVersion,
			ReadBatteryLevel,
			ReadManufacturer,
			ReadTallies,
			ReadDeviceInformation,
			ReadUserSettings,
			ReadSeizureSettings,
			ReadDeviceStatus,
			ReadDeviceSettings,
			ReadStepsHeader,
			ReadHourlySteps,
			ReadCurrentHour,
			ReadSignature,
			ReadSeizureBlocks,
			ReadSeizure,
			ReadSeizureTable,
			WriteStepsHeader,
			WriteDeviceSettings,
			WriteUserSettings,
			WriteExerciseSettings,
			WriteCompanySettings,
			WriteSignatureSettings,
			WriteSeizureSettings,
			WriteScreenFlow,
			WriteDeviceSensitivity,
			WriteDeviceStatus,
			WriteScreenDisplay,
			WriteDeviceMode,
			ClearEEProm,
			WsGetDeviceInfo,
			WsUploadTallies,
			WsUploadSteps,
			WsUploadSignature,
			WsUploadProfile,
			WsUnpairDevice,
			WsUploadSeizure,
			WsSendNotifySettingsUpdate,
			WsActivateDeviceWithMember,
			WsUploadCommandResponse,
			WsSendAppInfo
		}

		public enum StriivSyncHandlerSequence
		{
			EnableFE23,
			Ack,
			RegisterRead,
			RegisterWrite,
			FileLoadList,
			DeviceInfo
		}

		//Streamlines DB Web Services Method Names
		public enum StreamlinesWebServiceMethod
		{
			SendApplicationInfo,
			ValidateUser,
			UploadData,
			UploadSignData,
			UploadSeizureData,
			UploadTallies,
			UploadSurveyResponse,
			UploadDataCompleted,
			UploadCommandResponse,
			UploadStepDataHeader,
			UploadRecordTimeData,
			UploadActivitySummary,
			GetDeviceInfo,
			ActivateDeviceWithMember,
			NotifySettingsUpdate,
			NotifyMessageSettingsUpdate,
			NotifyAlarmSettingsUpdate,
			NotifyFirmwareUpdate,
			GetOnlinePortal,
			GetFirmware,
			GenerateSerial,
			UnpairMemberDevice,
			RegisterTestDevice,
			GetMesagges,
			GetActivitySummary,
		}


		//Derm DB Web Services Method Names
		public enum DermWebServiceMethod
		{
			ENCRYPT_CREDENTIALS,
			SINGLE_SIGN_ON,
			VALIDATE_USER,
		}

		public enum ScanType
		{
			ACTIVATION,
			SYNCING
		}

	}
}

