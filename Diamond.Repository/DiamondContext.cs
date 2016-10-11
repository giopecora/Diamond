namespace Diamond.Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain.Entities;

    public partial class DiamondContext : DbContext
    {
        public DiamondContext()
            : base("name=DiamondContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Estoque_Entrada> Estoque_Entrada { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Pedido_Item> Pedido_Item { get; set; }
        public virtual DbSet<Perfil> Perfil { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Usuario_Perfil> Usuario_Perfil { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.nm_Categoria)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Produto)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.nm_Logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.nm_Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.ds_Complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.nr_CEP)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.nm_Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.ds_Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .HasMany(e => e.Usuario)
                .WithMany(e => e.Endereco)
                .Map(m => m.ToTable("Usuario_Endereco").MapLeftKey("id_Endereco").MapRightKey("id_Usuario"));

            modelBuilder.Entity<Pedido>()
                .HasMany(e => e.Pedido_Item)
                .WithRequired(e => e.Pedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.nm_Perfil)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.nm_Produto)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.ds_produto)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.ds_imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.Estoque_Entrada)
                .WithRequired(e => e.Produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.Pedido_Item)
                .WithRequired(e => e.Produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nm_Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nm_login)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.ds_senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Pedido)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
