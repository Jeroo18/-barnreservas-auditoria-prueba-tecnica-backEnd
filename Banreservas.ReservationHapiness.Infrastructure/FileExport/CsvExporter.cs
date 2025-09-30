//using CsvHelper;
//using Banreservas.ReservationHapiness.Application.Features.OptionTypes.Queries.GetOptionTypesExport;
////using Banreservas.ReservationHapiness.Application.Features.SurveyTypes.Queries.GetSurvetTypesExport;
//using Banreservas.ReservationHapiness.Application.Interfaces.Infrastructure;

//namespace Banreservas.ReservationHapiness.Infrastructure.FileExport
//{
//    public class CsvExporter : ICsvExporter
//    {
//        //public byte[] ExportSurveyTypesToCsv(List<SurveyTypeExportDto> surveytyTypeExportDtos)
//        //{
//        //    using var memoryStream = new MemoryStream();
//        //    using (var streamWriter = new StreamWriter(memoryStream))
//        //    {
//        //        using var csvWriter = new CsvWriter(streamWriter);
//        //        csvWriter.WriteRecords(surveytyTypeExportDtos);
//        //    }

//        //    return memoryStream.ToArray();
//        //}

//        public byte[] ExportOptionTypesToCsv(List<OptionTypeExportDto> optionTypeExportDto)
//        {
//            using var memoryStream = new MemoryStream();
//            using (var streamWriter = new StreamWriter(memoryStream))
//            {
//                using var csvWriter = new CsvWriter(streamWriter);
//                csvWriter.WriteRecords(optionTypeExportDto);
//            }

//            return memoryStream.ToArray();
//        }
//    }
//}
