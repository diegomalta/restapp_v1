using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using restapp.Domain.Model;

namespace restapp.Data.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("CATProductosVenta");
            builder.HasKey(e => e.ProductId).HasName("iIdProducto");
            builder.Property(e => e.CategoryId).HasColumnName("iIDGrupoProdVenta");
            builder.Property(e => e.Name).HasColumnName("sNombre");
            builder.Property(e => e.Description).HasColumnName("sDescripcion");
            builder.Property(e => e.Price).HasColumnName("dPrecioVenta");
            builder.Property(e => e.Color).HasColumnName("sColor");
            builder.Property(e => e.IsActive).HasColumnName("bActiva");
            builder.Property(e => e.PreparationPointId).HasColumnName("iIDPuntoEntrega");
            builder.Property(e => e.SubCategoryId).HasColumnName("iIDSubGrupoProdVenta");
        }
    }
}
