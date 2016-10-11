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

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Estoque_Entrada> Estoque_Entrada { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Pedido_Item> Pedido_Item { get; set; }
        public virtual DbSet<Perfil> Perfis { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Usuario_Perfil> Usuario_Perfil { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .Property(e => e.NM_Categoria)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Produtoes)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.NM_Logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.NM_Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.DS_Complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.NR_CEP)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.NM_Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.DS_Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .HasMany(e => e.Usuarios)
                .WithMany(e => e.Enderecoes)
                .Map(m => m.ToTable("Usuario_Endereco").MapLeftKey("ID_Endereco").MapRightKey("ID_Usuario"));

            modelBuilder.Entity<Pedido>()
                .HasMany(e => e.Pedido_Item)
                .WithRequired(e => e.Pedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.NM_Perfil)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.NM_Produto)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.DS_produto)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.DS_imagem)
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
                .Property(e => e.NM_Usuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NM_login)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.DS_senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Pedidoes)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
