using Account.Common.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Account.Service.Configuration;

public class AttachmentConfiguration : BaseEntityConfiguration<Attachment>
{
    public override void Configure(EntityTypeBuilder<Attachment> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Data).IsRequired();
        builder.Property(x => x.Name).HasMaxLength(70).IsRequired().IsUnicode();
        builder.HasOne(bp => bp.Transaction).WithMany(x => x.Attachments).HasForeignKey(x => x.TransactionId).IsRequired();
    }
}