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

        public virtual DbSet<Bandeira> Bandeiras { get; set; }
        public virtual DbSet<Cartao> Cartoes { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Estoque_Entrada> Estoque_Entrada { get; set; }
        public virtual DbSet<Estoque_Saida> Estoque_Saida { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Pedido_Itens> Pedido_Itens { get; set; }
        public virtual DbSet<Perfil> Perfis { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Produto_Imagens> Produto_Imagens { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Usuario_Perfis> Usuario_Perfis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bandeira>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cartao>()
                .Property(e => e.Numero)
                .IsUnicode(false);

            modelBuilder.Entity<Cartao>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Cartao>()
                .Property(e => e.Vencimento)
                .IsUnicode(false);

            modelBuilder.Entity<Cartao>()
                .Property(e => e.CCR)
                .IsUnicode(false);

            modelBuilder.Entity<Cartao>()
                .HasMany(e => e.Pedidoes)
                .WithRequired(e => e.Cartao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Produtoes)
                .WithRequired(e => e.Categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Logradouro)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.CEP)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .Property(e => e.Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Endereco>()
                .HasMany(e => e.Pedidoes)
                .WithRequired(e => e.Endereco)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Marca>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Marca>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Marca>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Pedido>()
                .HasMany(e => e.Pedido_Itens)
                .WithRequired(e => e.Pedido)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Pedido_Itens>()
                .HasMany(e => e.Estoque_Saida)
                .WithOptional(e => e.Pedido_Itens)
                .HasForeignKey(e => e.PedidoItemId);

            modelBuilder.Entity<Perfil>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Perfil>()
                .HasMany(e => e.Usuario_Perfis)
                .WithRequired(e => e.Perfil)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .Property(e => e.ImagemPrincipal)
                .IsUnicode(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.Estoque_Entrada)
                .WithRequired(e => e.Produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.Estoque_Saida)
                .WithRequired(e => e.Produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto>()
                .HasMany(e => e.Pedido_Itens)
                .WithRequired(e => e.Produto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Produto_Imagens>()
                .Property(e => e.Imagem)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Cartaos)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Enderecoes)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Pedidoes)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Usuario_Perfis)
                .WithRequired(e => e.Usuario)
                .WillCascadeOnDelete(false);
        }
    }
}
