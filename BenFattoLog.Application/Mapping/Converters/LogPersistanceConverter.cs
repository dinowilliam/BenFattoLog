using System;
using System.ComponentModel;
using System.Globalization;

namespace BenFattoLog.Application.Mapping.Converters {
	
	using BenFattoLog.Application.DTO;
    using BenFattoLog.DAL.Repositorys.Models;

    public sealed class LogPersistanceConverter : TypeConverter 	{
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType) => destinationType == typeof(LogPersistance);		

		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType) {
			
			var concreteValue = (LogDTO) value;
			var result = new LogPersistance {
				IpAddress = concreteValue.IpAddress
			};

			return result;
		}
	}
}
