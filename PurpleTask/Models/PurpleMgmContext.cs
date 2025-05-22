using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PurpleTask.Models;

public partial class PurpleMgmContext : DbContext
{
    public PurpleMgmContext()
    {
    }

    public PurpleMgmContext(DbContextOptions<PurpleMgmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ac> Acs { get; set; }

    public virtual DbSet<Led> Led { get; set; }

    public virtual DbSet<AreAtu> AreAtus { get; set; }

    public virtual DbSet<AvlItm> AvlItms { get; set; }

    public virtual DbSet<Cec> Cecs { get; set; }

    public virtual DbSet<Ctt> Ctts { get; set; }

    public virtual DbSet<Ep> Eps { get; set; }

    public virtual DbSet<Fot> Fots { get; set; }

    public virtual DbSet<Ist> Ists { get; set; }

    public virtual DbSet<Itm> Itms { get; set; }

    public virtual DbSet<Loc> Locs { get; set; }

    public virtual DbSet<NvlCnh> NvlCnhs { get; set; }

    public virtual DbSet<Rmd> Rmds { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<Usr> Usrs { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       // => optionsBuilder.UseSqlServer("Server=localhost; Database=Purple_mgm; User Id=sa; Password=sa.2014; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ac>(entity =>
        {
            entity.HasKey(e => e.AcsId);

            entity.ToTable("ACS");

            entity.Property(e => e.AcsId).HasColumnName("ACS_ID");
            entity.Property(e => e.AcsDatTms)
                .HasColumnType("datetime")
                .HasColumnName("ACS_DAT_TMS");
            entity.Property(e => e.AcsUsrId).HasColumnName("ACS_USR_ID");
        });

        modelBuilder.Entity<AreAtu>(entity =>
        {
            entity.ToTable("ARE_ATU");

            entity.Property(e => e.AreAtuId).HasColumnName("ARE_ATU_ID");
            entity.Property(e => e.AreAtuDes)
                .HasMaxLength(50)
                .HasColumnName("ARE_ATU_DES");
        });

        modelBuilder.Entity<AvlItm>(entity =>
        {
            entity.HasKey(e => e.AvlItmId).IsClustered(false);

            entity.ToTable("AVL_ITM");

            entity.Property(e => e.AvlItmId).HasColumnName("AVL_ITM_ID");
            entity.Property(e => e.AvlItmAnd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("AVL_ITM_AND");
            entity.Property(e => e.AvlItmCecId).HasColumnName("AVL_ITM_CEC_ID");
            entity.Property(e => e.AvlItmComp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AVL_ITM_COMP");
            entity.Property(e => e.AvlItmCon).HasColumnName("AVL_ITM_CON");
            entity.Property(e => e.AvlItmDatAlt)
                .HasColumnType("datetime")
                .HasColumnName("AVL_ITM_DAT_ALT");
            entity.Property(e => e.AvlItmDatExc)
                .HasColumnType("datetime")
                .HasColumnName("AVL_ITM_DAT_EXC");
            entity.Property(e => e.AvlItmDatInc)
                .HasColumnType("datetime")
                .HasColumnName("AVL_ITM_DAT_INC");
            entity.Property(e => e.AvlItmDes)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AVL_ITM_DES");
            entity.Property(e => e.AvlItmEpsId).HasColumnName("AVL_ITM_EPS_ID");
            entity.Property(e => e.AvlItmIstId).HasColumnName("AVL_ITM_IST_ID");
            entity.Property(e => e.AvlItmLocId).HasColumnName("AVL_ITM_LOC_ID");
            entity.Property(e => e.AvlItmNumSer)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("AVL_ITM_NUM_SER");
            entity.Property(e => e.AvlItmPlq)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("AVL_ITM_PLQ");
            entity.Property(e => e.AvlItmPlqAnt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("AVL_ITM_PLQ_ANT");
            entity.Property(e => e.AvlItmSetId).HasColumnName("AVL_ITM_SET_ID");
            entity.Property(e => e.AvlItmSit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("AVL_ITM_SIT");
            entity.Property(e => e.AvlItmSts).HasColumnName("AVL_ITM_STS");
            entity.Property(e => e.AvlItmUsrAltId).HasColumnName("AVL_ITM_USR_ALT_ID");
            entity.Property(e => e.AvlItmUsrExcId).HasColumnName("AVL_ITM_USR_EXC_ID");
            entity.Property(e => e.AvlItmUsrIncId).HasColumnName("AVL_ITM_USR_INC_ID");
            entity.Property(e => e.AvlItmVlrAqs)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("AVL_ITM_VLR_AQS");

            entity.HasOne(d => d.AvlItmEps).WithMany(p => p.AvlItms)
                .HasForeignKey(d => d.AvlItmEpsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AVL_ITM_CEC_ID");

            entity.HasOne(d => d.AvlItmLoc).WithMany(p => p.AvlItms)
                .HasForeignKey(d => d.AvlItmLocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AVL_ITM_LOC_ID");

            entity.HasOne(d => d.AvlItmSet).WithMany(p => p.AvlItms)
                .HasForeignKey(d => d.AvlItmSetId)
                .HasConstraintName("FK_AVL_ITM_SET_ID");

            entity.HasOne(d => d.AvlItmUsrAlt).WithMany(p => p.AvlItmAvlItmUsrAlts)
                .HasForeignKey(d => d.AvlItmUsrAltId)
                .HasConstraintName("FK_AVL_ITM_USR_ALT_ID");

            entity.HasOne(d => d.AvlItmUsrExc).WithMany(p => p.AvlItmAvlItmUsrExcs)
                .HasForeignKey(d => d.AvlItmUsrExcId)
                .HasConstraintName("FK_AVL_ITM_USR_EXC_ID");

            entity.HasOne(d => d.AvlItmUsrInc).WithMany(p => p.AvlItmAvlItmUsrIncs)
                .HasForeignKey(d => d.AvlItmUsrIncId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AVL_ITM_USR_INC_ID");
        });

        modelBuilder.Entity<Cec>(entity =>
        {
            entity.HasKey(e => e.CecId).IsClustered(false);

            entity.ToTable("CEC");

            entity.Property(e => e.CecId).HasColumnName("CEC_ID");
            entity.Property(e => e.CecCod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CEC_COD");
            entity.Property(e => e.CecDatAlt)
                .HasColumnType("datetime")
                .HasColumnName("CEC_DAT_ALT");
            entity.Property(e => e.CecDatExc)
                .HasColumnType("datetime")
                .HasColumnName("CEC_DAT_EXC");
            entity.Property(e => e.CecDatInc)
                .HasColumnType("datetime")
                .HasColumnName("CEC_DAT_INC");
            entity.Property(e => e.CecEpsId).HasColumnName("CEC_EPS_ID");
            entity.Property(e => e.CecIstId).HasColumnName("CEC_IST_ID");
            entity.Property(e => e.CecLocId).HasColumnName("CEC_LOC_ID");
            entity.Property(e => e.CecNom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CEC_NOM");
            entity.Property(e => e.CecSts).HasColumnName("CEC_STS");
            entity.Property(e => e.CecUsrAltId).HasColumnName("CEC_USR_ALT_ID");
            entity.Property(e => e.CecUsrExcId).HasColumnName("CEC_USR_EXC_ID");
            entity.Property(e => e.CecUsrIncId).HasColumnName("CEC_USR_INC_ID");

            entity.HasOne(d => d.CecEps).WithMany(p => p.Cecs)
                .HasForeignKey(d => d.CecEpsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CEC_EPS");

            entity.HasOne(d => d.CecLoc).WithMany(p => p.Cecs)
                .HasForeignKey(d => d.CecLocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CEC_LOC_ID");

            entity.HasOne(d => d.CecUsrAlt).WithMany(p => p.CecCecUsrAlts)
                .HasForeignKey(d => d.CecUsrAltId)
                .HasConstraintName("FK_CEC_USR_ALT_ID");

            entity.HasOne(d => d.CecUsrExc).WithMany(p => p.CecCecUsrExcs)
                .HasForeignKey(d => d.CecUsrExcId)
                .HasConstraintName("FK_CEC_USR_EXC_ID");

            entity.HasOne(d => d.CecUsrInc).WithMany(p => p.CecCecUsrIncs)
                .HasForeignKey(d => d.CecUsrIncId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CEC_USR_INC_ID");
        });

        modelBuilder.Entity<Ctt>(entity =>
        {
            entity.HasKey(e => e.CttId).IsClustered(false);

            entity.ToTable("CTT");

            entity.Property(e => e.CttId).HasColumnName("CTT_ID");
            entity.Property(e => e.CttCgo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CTT_CGO");
            entity.Property(e => e.CttDatAlt)
                .HasColumnType("datetime")
                .HasColumnName("CTT_DAT_ALT");
            entity.Property(e => e.CttDatExc)
                .HasColumnType("datetime")
                .HasColumnName("CTT_DAT_EXC");
            entity.Property(e => e.CttDatInc)
                .HasColumnType("datetime")
                .HasColumnName("CTT_DAT_INC");
            entity.Property(e => e.CttEml)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CTT_EML");
            entity.Property(e => e.CttEpsId).HasColumnName("CTT_EPS_ID");
            entity.Property(e => e.CttIstId).HasColumnName("CTT_IST_ID");
            entity.Property(e => e.CttLin)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("CTT_LIN");
            entity.Property(e => e.CttNom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CTT_NOM");
            entity.Property(e => e.CttOri)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CTT_ORI");
            entity.Property(e => e.CttSts).HasColumnName("CTT_STS");
            entity.Property(e => e.CttTel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CTT_TEL");
            entity.Property(e => e.CttTip)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CTT_TIP");
            entity.Property(e => e.CttTwi)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CTT_TWI");
            entity.Property(e => e.CttUsrAltId).HasColumnName("CTT_USR_ALT_ID");
            entity.Property(e => e.CttUsrExcId).HasColumnName("CTT_USR_EXC_ID");
            entity.Property(e => e.CttUsrId).HasColumnName("CTT_USR_ID");
            entity.Property(e => e.CttUsrIncId).HasColumnName("CTT_USR_INC_ID");

            entity.HasOne(d => d.CttEps).WithMany(p => p.Ctts)
                .HasForeignKey(d => d.CttEpsId)
                .HasConstraintName("FK_CTT_EPS");

            entity.HasOne(d => d.CttUsrAlt).WithMany(p => p.CttCttUsrAlts)
                .HasForeignKey(d => d.CttUsrAltId)
                .HasConstraintName("FK_CTT_USR_ALT_ID");

            entity.HasOne(d => d.CttUsrExc).WithMany(p => p.CttCttUsrExcs)
                .HasForeignKey(d => d.CttUsrExcId)
                .HasConstraintName("FK_CTT_USR_EXC_ID");

            entity.HasOne(d => d.CttUsr).WithMany(p => p.CttCttUsrs)
                .HasForeignKey(d => d.CttUsrId)
                .HasConstraintName("FK_CTT_USR_ID");

            entity.HasOne(d => d.CttUsrInc).WithMany(p => p.CttCttUsrIncs)
                .HasForeignKey(d => d.CttUsrIncId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CTT_USR_INC_ID");
        });

        modelBuilder.Entity<Ep>(entity =>
        {
            entity.HasKey(e => e.EpsId).IsClustered(false);

            entity.ToTable("EPS");

            entity.Property(e => e.EpsId).HasColumnName("EPS_ID");
            entity.Property(e => e.EpsBrr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EPS_BRR");
            entity.Property(e => e.EpsCep)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("EPS_CEP");
            entity.Property(e => e.EpsCid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EPS_CID");
            entity.Property(e => e.EpsCnpj)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EPS_CNPJ");
            entity.Property(e => e.EpsDatAlt)
                .HasColumnType("datetime")
                .HasColumnName("EPS_DAT_ALT");
            entity.Property(e => e.EpsDatExc)
                .HasColumnType("datetime")
                .HasColumnName("EPS_DAT_EXC");
            entity.Property(e => e.EpsDatInc)
                .HasColumnType("datetime")
                .HasColumnName("EPS_DAT_INC");
            entity.Property(e => e.EpsDatUltAvl)
                .HasColumnType("datetime")
                .HasColumnName("EPS_DAT_ULT_AVL");
            entity.Property(e => e.EpsEdr)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EPS_EDR");
            entity.Property(e => e.EpsEdrCmp)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("EPS_EDR_CMP");
            entity.Property(e => e.EpsIstId).HasColumnName("EPS_IST_ID");
            entity.Property(e => e.EpsNom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EPS_NOM");
            entity.Property(e => e.EpsNomFnt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EPS_NOM_FNT");
            entity.Property(e => e.EpsNumEdr)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("EPS_NUM_EDR");
            entity.Property(e => e.EpsObs)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("EPS_OBS");
            entity.Property(e => e.EpsPai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EPS_PAI");
            entity.Property(e => e.EpsQtdItm).HasColumnName("EPS_QTD_ITM");
            entity.Property(e => e.EpsSit)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EPS_SIT");
            entity.Property(e => e.EpsSts).HasColumnName("EPS_STS");
            entity.Property(e => e.EpsUf)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("EPS_UF");
            entity.Property(e => e.EpsUsrAltId).HasColumnName("EPS_USR_ALT_ID");
            entity.Property(e => e.EpsUsrExcId).HasColumnName("EPS_USR_EXC_ID");
            entity.Property(e => e.EpsUsrIncId).HasColumnName("EPS_USR_INC_ID");
            entity.Property(e => e.EpsVlrItm)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("EPS_VLR_ITM");

            entity.HasOne(d => d.EpsIst).WithMany(p => p.Eps)
                .HasForeignKey(d => d.EpsIstId)
                .HasConstraintName("FK_EPS_IST");

            entity.HasOne(d => d.EpsUsrAlt).WithMany(p => p.EpEpsUsrAlts)
                .HasForeignKey(d => d.EpsUsrAltId)
                .HasConstraintName("FK_EPS_USR_ALT_ID");

            entity.HasOne(d => d.EpsUsrExc).WithMany(p => p.EpEpsUsrExcs)
                .HasForeignKey(d => d.EpsUsrExcId)
                .HasConstraintName("FK_EPS_USR_EXC_ID");

            entity.HasOne(d => d.EpsUsrInc).WithMany(p => p.EpEpsUsrIncs)
                .HasForeignKey(d => d.EpsUsrIncId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EPS_USR_INC_ID");
        });

        modelBuilder.Entity<Fot>(entity =>
        {
            entity.ToTable("FOT");

            entity.Property(e => e.FotId).HasColumnName("FOT_ID");
            entity.Property(e => e.FotDatInc)
                .HasColumnType("datetime")
                .HasColumnName("FOT_DAT_INC");
            entity.Property(e => e.FotLeg)
                .HasMaxLength(200)
                .HasColumnName("FOT_LEG");
            entity.Property(e => e.FotPat)
                .HasMaxLength(200)
                .HasColumnName("FOT_PAT");
            entity.Property(e => e.FotTit)
                .HasMaxLength(200)
                .HasColumnName("FOT_TIT");
            entity.Property(e => e.FotUsrId).HasColumnName("FOT_USR_ID");
        });

        modelBuilder.Entity<Ist>(entity =>
        {
            entity.ToTable("IST");

            entity.Property(e => e.IstId).HasColumnName("IST_ID");
            entity.Property(e => e.IstCnpj)
                .HasMaxLength(50)
                .HasColumnName("IST_CNPJ");
            entity.Property(e => e.IstNomFnt)
                .HasMaxLength(100)
                .HasColumnName("IST_NOM_FNT");
            entity.Property(e => e.IstSts).HasColumnName("IST_STS");
            entity.Property(e => e.IstUsrAltId).HasColumnName("IST_USR_ALT_ID");
            entity.Property(e => e.IstUsrDatAlt)
                .HasColumnType("datetime")
                .HasColumnName("IST_USR_DAT_ALT");
            entity.Property(e => e.IstUsrDatInc)
                .HasColumnType("datetime")
                .HasColumnName("IST_USR_DAT_INC");
            entity.Property(e => e.IstUsrIncId).HasColumnName("IST_USR_INC_ID");
        });

        modelBuilder.Entity<Itm>(entity =>
        {
            entity.HasKey(e => e.ItmId).IsClustered(false);

            entity.ToTable("ITM");

            entity.Property(e => e.ItmId).HasColumnName("ITM_ID");
            entity.Property(e => e.ItmDatAlt)
                .HasColumnType("datetime")
                .HasColumnName("ITM_DAT_ALT");
            entity.Property(e => e.ItmDatExc)
                .HasColumnType("datetime")
                .HasColumnName("ITM_DAT_EXC");
            entity.Property(e => e.ItmDatInc)
                .HasColumnType("datetime")
                .HasColumnName("ITM_DAT_INC");
            entity.Property(e => e.ItmIstId).HasColumnName("ITM_IST_ID");
            entity.Property(e => e.ItmNom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ITM_NOM");
            entity.Property(e => e.ItmSts).HasColumnName("ITM_STS");
            entity.Property(e => e.ItmUsrAltId).HasColumnName("ITM_USR_ALT_ID");
            entity.Property(e => e.ItmUsrExcId).HasColumnName("ITM_USR_EXC_ID");
            entity.Property(e => e.ItmUsrIncId).HasColumnName("ITM_USR_INC_ID");

            entity.HasOne(d => d.ItmUsrAlt).WithMany(p => p.ItmItmUsrAlts)
                .HasForeignKey(d => d.ItmUsrAltId)
                .HasConstraintName("FK_ITM_USR_ALT_ID");

            entity.HasOne(d => d.ItmUsrExc).WithMany(p => p.ItmItmUsrExcs)
                .HasForeignKey(d => d.ItmUsrExcId)
                .HasConstraintName("FK_ITM_USR_EXC_ID");

            entity.HasOne(d => d.ItmUsrInc).WithMany(p => p.ItmItmUsrIncs)
                .HasForeignKey(d => d.ItmUsrIncId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ITM_USR_INC_ID");
        });

        modelBuilder.Entity<Loc>(entity =>
        {
            entity.HasKey(e => e.LocId).IsClustered(false);

            entity.ToTable("LOC");

            entity.Property(e => e.LocId).HasColumnName("LOC_ID");
            entity.Property(e => e.LocCod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("LOC_COD");
            entity.Property(e => e.LocDatAlt)
                .HasColumnType("datetime")
                .HasColumnName("LOC_DAT_ALT");
            entity.Property(e => e.LocDatExc)
                .HasColumnType("datetime")
                .HasColumnName("LOC_DAT_EXC");
            entity.Property(e => e.LocDatInc)
                .HasColumnType("datetime")
                .HasColumnName("LOC_DAT_INC");
            entity.Property(e => e.LocEpsId).HasColumnName("LOC_EPS_ID");
            entity.Property(e => e.LocIstId).HasColumnName("LOC_IST_ID");
            entity.Property(e => e.LocNom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LOC_NOM");
            entity.Property(e => e.LocSts).HasColumnName("LOC_STS");
            entity.Property(e => e.LocUsrAltId).HasColumnName("LOC_USR_ALT_ID");
            entity.Property(e => e.LocUsrExcId).HasColumnName("LOC_USR_EXC_ID");
            entity.Property(e => e.LocUsrIncId).HasColumnName("LOC_USR_INC_ID");

            entity.HasOne(d => d.LocEps).WithMany(p => p.Locs)
                .HasForeignKey(d => d.LocEpsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LOC_EPS");

            entity.HasOne(d => d.LocUsrAlt).WithMany(p => p.LocLocUsrAlts)
                .HasForeignKey(d => d.LocUsrAltId)
                .HasConstraintName("FK_LOC_USR_ALT_ID");

            entity.HasOne(d => d.LocUsrExc).WithMany(p => p.LocLocUsrExcs)
                .HasForeignKey(d => d.LocUsrExcId)
                .HasConstraintName("FK_LOC_USR_EXC_ID");

            entity.HasOne(d => d.LocUsrInc).WithMany(p => p.LocLocUsrIncs)
                .HasForeignKey(d => d.LocUsrIncId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LOC_USR_INC_ID");
        });

        modelBuilder.Entity<NvlCnh>(entity =>
        {
            entity.ToTable("NVL_CNH");

            entity.Property(e => e.NvlCnhId).HasColumnName("NVL_CNH_ID");
            entity.Property(e => e.NvlCnhDes)
                .HasMaxLength(50)
                .HasColumnName("NVL_CNH_DES");
        });

        modelBuilder.Entity<Rmd>(entity =>
        {
            entity.ToTable("RMD");

            entity.Property(e => e.RmdId).HasColumnName("RMD_ID");
            entity.Property(e => e.RmdDatInc)
                .HasColumnType("datetime")
                .HasColumnName("RMD_DAT_INC");
            entity.Property(e => e.RmdIstId).HasColumnName("RMD_IST_ID");
            entity.Property(e => e.RmdUsrId).HasColumnName("RMD_USR_ID");
            entity.Property(e => e.RmdUsrUsrId).HasColumnName("RMD_USR_USR_ID");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => e.SetId).IsClustered(false);

            entity.ToTable("SET");

            entity.Property(e => e.SetId).HasColumnName("SET_ID");
            entity.Property(e => e.SetCod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SET_COD");
            entity.Property(e => e.SetDatAlt)
                .HasColumnType("datetime")
                .HasColumnName("SET_DAT_ALT");
            entity.Property(e => e.SetDatExc)
                .HasColumnType("datetime")
                .HasColumnName("SET_DAT_EXC");
            entity.Property(e => e.SetDatInc)
                .HasColumnType("datetime")
                .HasColumnName("SET_DAT_INC");
            entity.Property(e => e.SetEpsId).HasColumnName("SET_EPS_ID");
            entity.Property(e => e.SetIstId).HasColumnName("SET_IST_ID");
            entity.Property(e => e.SetLocId).HasColumnName("SET_LOC_ID");
            entity.Property(e => e.SetNom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SET_NOM");
            entity.Property(e => e.SetSts).HasColumnName("SET_STS");
            entity.Property(e => e.SetUsrAltId).HasColumnName("SET_USR_ALT_ID");
            entity.Property(e => e.SetUsrExcId).HasColumnName("SET_USR_EXC_ID");
            entity.Property(e => e.SetUsrIncId).HasColumnName("SET_USR_INC_ID");

            entity.HasOne(d => d.SetEps).WithMany(p => p.Sets)
                .HasForeignKey(d => d.SetEpsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SET_EPS");

            entity.HasOne(d => d.SetLoc).WithMany(p => p.Sets)
                .HasForeignKey(d => d.SetLocId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SET_LOC_ID");

            entity.HasOne(d => d.SetUsrAlt).WithMany(p => p.SetSetUsrAlts)
                .HasForeignKey(d => d.SetUsrAltId)
                .HasConstraintName("FK_SET_USR_ALT_ID");

            entity.HasOne(d => d.SetUsrExc).WithMany(p => p.SetSetUsrExcs)
                .HasForeignKey(d => d.SetUsrExcId)
                .HasConstraintName("FK_SET_USR_EXC_ID");

            entity.HasOne(d => d.SetUsrInc).WithMany(p => p.SetSetUsrIncs)
                .HasForeignKey(d => d.SetUsrIncId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SET_USR_INC_ID");
        });

        modelBuilder.Entity<Usr>(entity =>
        {
            entity.ToTable("USR");

            entity.Property(e => e.UsrId).HasColumnName("USR_ID");
            entity.Property(e => e.UsrAreAtu).HasColumnName("USR_ARE_ATU");
            entity.Property(e => e.UsrAss).HasColumnName("USR_ASS");
            entity.Property(e => e.UsrCidTra)
                .HasMaxLength(50)
                .HasColumnName("USR_CID_TRA");
            entity.Property(e => e.UsrCod)
                .HasMaxLength(50)
                .HasColumnName("USR_COD");
            entity.Property(e => e.UsrDatAdm)
                .HasColumnType("datetime")
                .HasColumnName("USR_DAT_ADM");
            entity.Property(e => e.UsrDatAlt)
                .HasColumnType("datetime")
                .HasColumnName("USR_DAT_ALT");
            entity.Property(e => e.UsrDatExl)
                .HasColumnType("datetime")
                .HasColumnName("USR_DAT_EXL");
            entity.Property(e => e.UsrDatInc)
                .HasColumnType("datetime")
                .HasColumnName("USR_DAT_INC");
            entity.Property(e => e.UsrDatNasc)
                .HasColumnType("datetime")
                .HasColumnName("USR_DAT_NASC");
            entity.Property(e => e.UsrEma)
                .HasMaxLength(200)
                .HasColumnName("USR_EMA");
            entity.Property(e => e.UsrEmlVld).HasColumnName("USR_EML_VLD");
            entity.Property(e => e.UsrEpsId).HasColumnName("USR_EPS_ID");
            entity.Property(e => e.UsrFot)
                .HasMaxLength(200)
                .HasColumnName("USR_FOT");
            entity.Property(e => e.UsrIstId).HasColumnName("USR_IST_ID");
            entity.Property(e => e.UsrLgaPpg)
                .HasMaxLength(200)
                .HasColumnName("USR_LGA_PPG");
            entity.Property(e => e.UsrNom)
                .HasMaxLength(100)
                .HasColumnName("USR_NOM");
            entity.Property(e => e.UsrNvlCnh).HasColumnName("USR_NVL_CNH");
            entity.Property(e => e.UsrPfl).HasColumnName("USR_PFL");
            entity.Property(e => e.UsrSal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("USR_SAL");
            entity.Property(e => e.UsrSex)
                .HasMaxLength(10)
                .HasColumnName("USR_SEX");
            entity.Property(e => e.UsrSnh)
                .HasMaxLength(200)
                .HasColumnName("USR_SNH");
            entity.Property(e => e.UsrStaTra)
                .HasMaxLength(50)
                .HasColumnName("USR_STA_TRA");

            entity.HasOne(d => d.UsrEps).WithMany(p => p.Usrs)
                .HasForeignKey(d => d.UsrEpsId)
                .HasConstraintName("FK_USR_EPS");

            entity.HasOne(d => d.UsrIst).WithMany(p => p.Usrs)
                .HasForeignKey(d => d.UsrIstId)
                .HasConstraintName("FK_USR_IST");
        });

        modelBuilder.Entity<Led>(entity =>
        {
            entity.HasKey(e => e.LedId).IsClustered(false);

            entity.ToTable("LEAD");

            entity.Property(e => e.LedId).HasColumnName("LEAD_ID");

            entity.Property(e => e.LedDatInc)
                .HasColumnType("datetime")
                .HasColumnName("LEAD_DAT_INC");

            entity.Property(e => e.LedNom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LEAD_NOM");

            entity.Property(e => e.LedMail)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("LEAD_MAIL");

            entity.Property(e => e.LedTel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LEAD_TEL");

            entity.Property(e => e.LedDes)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("LEAD_DES");

        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
