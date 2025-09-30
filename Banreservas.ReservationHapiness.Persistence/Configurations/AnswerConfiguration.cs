//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Banreservas.ReservationHapiness.Domain.Entities;

//namespace Banreservas.ReservationHapiness.Persistence.Configurations
//{
//    public class AnswerConfiguration

//        : IEntityTypeConfiguration<Answer>
//    {

//        public void Configure(EntityTypeBuilder<Answer> builder)
//        {
//            builder.HasKey(p => p.AnswerId);

//            builder.Property(p => p.AnswerValue)
//                .IsRequired()
//                .HasMaxLength(500);

//            builder.Property(p => p.IsActived)
//              .HasDefaultValue(true)
//              .IsRequired()
//              .HasMaxLength(50);

//            builder.Property(p => p.CreatedBy)
//               .HasMaxLength(50);

//            builder.Property(p => p.CreatedDate)
//            .IsRequired();

//            //builder.HasMany(p => p.AnswerOptions);

//            //builder.Navigation(p => p.AnswerOptions)
//            //   .AutoInclude();
//        }
//    }
//}
