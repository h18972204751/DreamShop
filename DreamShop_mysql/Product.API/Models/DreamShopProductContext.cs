using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Product.API.Models
{
    public partial class DreamShopProductContext : DbContext
    {
        public DreamShopProductContext()
        {
        }

        public DreamShopProductContext(DbContextOptions<DreamShopProductContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PmsAlbum> PmsAlbum { get; set; }
        public virtual DbSet<PmsAlbumPic> PmsAlbumPic { get; set; }
        public virtual DbSet<PmsBrand> PmsBrand { get; set; }
        public virtual DbSet<PmsComment> PmsComment { get; set; }
        public virtual DbSet<PmsCommentReplay> PmsCommentReplay { get; set; }
        public virtual DbSet<PmsFeightTemplate> PmsFeightTemplate { get; set; }
        public virtual DbSet<PmsMemberPrice> PmsMemberPrice { get; set; }
        public virtual DbSet<PmsProduct> PmsProduct { get; set; }
        public virtual DbSet<PmsProductAttribute> PmsProductAttribute { get; set; }
        public virtual DbSet<PmsProductAttributeCategory> PmsProductAttributeCategory { get; set; }
        public virtual DbSet<PmsProductAttributeValue> PmsProductAttributeValue { get; set; }
        public virtual DbSet<PmsProductCategory> PmsProductCategory { get; set; }
        public virtual DbSet<PmsProductCategoryAttributeRelation> PmsProductCategoryAttributeRelation { get; set; }
        public virtual DbSet<PmsProductFullReduction> PmsProductFullReduction { get; set; }
        public virtual DbSet<PmsProductLadder> PmsProductLadder { get; set; }
        public virtual DbSet<PmsProductOperateLog> PmsProductOperateLog { get; set; }
        public virtual DbSet<PmsProductVertifyRecord> PmsProductVertifyRecord { get; set; }
        public virtual DbSet<PmsSkuStock> PmsSkuStock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=49.235.230.16;userid=root;pwd=Wei19960705.;port=3306;database=dreamshop.product;sslmode=none", x => x.ServerVersion("5.7.24-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PmsAlbum>(entity =>
            {
                entity.ToTable("pms_album");

                entity.HasComment("相册表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CoverPic)
                    .HasColumnName("cover_pic")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PicCount)
                    .HasColumnName("pic_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PmsAlbumPic>(entity =>
            {
                entity.ToTable("pms_album_pic");

                entity.HasComment("画册图片表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AlbumId)
                    .HasColumnName("album_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Pic)
                    .HasColumnName("pic")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PmsBrand>(entity =>
            {
                entity.ToTable("pms_brand");

                entity.HasComment("品牌表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BigPic)
                    .HasColumnName("big_pic")
                    .HasColumnType("varchar(255)")
                    .HasComment("专区大图")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BrandStory)
                    .HasColumnName("brand_story")
                    .HasColumnType("text")
                    .HasComment("品牌故事")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FactoryStatus)
                    .HasColumnName("factory_status")
                    .HasColumnType("int(1)")
                    .HasComment("是否为品牌制造商：0->不是；1->是");

                entity.Property(e => e.FirstLetter)
                    .HasColumnName("first_letter")
                    .HasColumnType("varchar(8)")
                    .HasComment("首字母")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasColumnType("varchar(255)")
                    .HasComment("品牌logo")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductCommentCount)
                    .HasColumnName("product_comment_count")
                    .HasColumnType("int(11)")
                    .HasComment("产品评论数量");

                entity.Property(e => e.ProductCount)
                    .HasColumnName("product_count")
                    .HasColumnType("int(11)")
                    .HasComment("产品数量");

                entity.Property(e => e.ShowStatus)
                    .HasColumnName("show_status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PmsComment>(entity =>
            {
                entity.ToTable("pms_comment");

                entity.HasComment("商品评价表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CollectCouont)
                    .HasColumnName("collect_couont")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.MemberIcon)
                    .HasColumnName("member_icon")
                    .HasColumnType("varchar(255)")
                    .HasComment("评论用户头像")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MemberIp)
                    .HasColumnName("member_ip")
                    .HasColumnType("varchar(64)")
                    .HasComment("评价的ip")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MemberNickName)
                    .HasColumnName("member_nick_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Pics)
                    .HasColumnName("pics")
                    .HasColumnType("varchar(1000)")
                    .HasComment("上传图片地址，以逗号隔开")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductAttribute)
                    .HasColumnName("product_attribute")
                    .HasColumnType("varchar(255)")
                    .HasComment("购买时的商品属性")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ProductName)
                    .HasColumnName("product_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ReadCount)
                    .HasColumnName("read_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ReplayCount)
                    .HasColumnName("replay_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShowStatus)
                    .HasColumnName("show_status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Star)
                    .HasColumnName("star")
                    .HasColumnType("int(3)")
                    .HasComment("评价星数：0->5");
            });

            modelBuilder.Entity<PmsCommentReplay>(entity =>
            {
                entity.ToTable("pms_comment_replay");

                entity.HasComment("产品评价回复表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CommentId)
                    .HasColumnName("comment_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.MemberIcon)
                    .HasColumnName("member_icon")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MemberNickName)
                    .HasColumnName("member_nick_name")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)")
                    .HasComment("评论人员类型；0->会员；1->管理员");
            });

            modelBuilder.Entity<PmsFeightTemplate>(entity =>
            {
                entity.ToTable("pms_feight_template");

                entity.HasComment("运费模版");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ChargeType)
                    .HasColumnName("charge_type")
                    .HasColumnType("int(1)")
                    .HasComment("计费类型:0->按重量；1->按件数");

                entity.Property(e => e.ContinmeFee)
                    .HasColumnName("continme_fee")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ContinueWeight)
                    .HasColumnName("continue_weight")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.Dest)
                    .HasColumnName("dest")
                    .HasColumnType("varchar(255)")
                    .HasComment("目的地（省、市）")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstFee)
                    .HasColumnName("first_fee")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("首费（元）");

                entity.Property(e => e.FirstWeight)
                    .HasColumnName("first_weight")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("首重kg");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PmsMemberPrice>(entity =>
            {
                entity.ToTable("pms_member_price");

                entity.HasComment("商品会员价格表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.MemberLevelId)
                    .HasColumnName("member_level_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.MemberLevelName)
                    .HasColumnName("member_level_name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MemberPrice)
                    .HasColumnName("member_price")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("会员价格");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<PmsProduct>(entity =>
            {
                entity.ToTable("pms_product");

                entity.HasComment("商品信息");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AlbumPics)
                    .HasColumnName("album_pics")
                    .HasColumnType("varchar(255)")
                    .HasComment("画册图片，连产品图片限制为5张，以逗号分割")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BrandName)
                    .HasColumnName("brand_name")
                    .HasColumnType("varchar(255)")
                    .HasComment("品牌名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DeleteStatus)
                    .HasColumnName("delete_status")
                    .HasColumnType("int(1)")
                    .HasComment("删除状态：0->未删除；1->已删除");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasComment("商品描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DetailDesc)
                    .HasColumnName("detail_desc")
                    .HasColumnType("text")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DetailHtml)
                    .HasColumnName("detail_html")
                    .HasColumnType("text")
                    .HasComment("产品详情网页内容")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DetailMobileHtml)
                    .HasColumnName("detail_mobile_html")
                    .HasColumnType("text")
                    .HasComment("移动端网页详情")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DetailTitle)
                    .HasColumnName("detail_title")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FeightTemplateId)
                    .HasColumnName("feight_template_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.GiftGrowth)
                    .HasColumnName("gift_growth")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("赠送的成长值");

                entity.Property(e => e.GiftPoint)
                    .HasColumnName("gift_point")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("赠送的积分");

                entity.Property(e => e.Keywords)
                    .HasColumnName("keywords")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LowStock)
                    .HasColumnName("low_stock")
                    .HasColumnType("int(11)")
                    .HasComment("库存预警值");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NewStatus)
                    .HasColumnName("new_status")
                    .HasColumnType("int(1)")
                    .HasComment("新品状态:0->不是新品；1->新品");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OriginalPrice)
                    .HasColumnName("original_price")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("市场价");

                entity.Property(e => e.Pic)
                    .HasColumnName("pic")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PreviewStatus)
                    .HasColumnName("preview_status")
                    .HasColumnType("int(1)")
                    .HasComment("是否为预告商品：0->不是；1->是");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ProductAttributeCategoryId)
                    .HasColumnName("product_attribute_category_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ProductCategoryId)
                    .HasColumnName("product_category_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ProductCategoryName)
                    .HasColumnName("product_category_name")
                    .HasColumnType("varchar(255)")
                    .HasComment("商品分类名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductSn)
                    .IsRequired()
                    .HasColumnName("product_sn")
                    .HasColumnType("varchar(64)")
                    .HasComment("货号")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PromotionEndTime)
                    .HasColumnName("promotion_end_time")
                    .HasColumnType("datetime")
                    .HasComment("促销结束时间");

                entity.Property(e => e.PromotionPerLimit)
                    .HasColumnName("promotion_per_limit")
                    .HasColumnType("int(11)")
                    .HasComment("活动限购数量");

                entity.Property(e => e.PromotionPrice)
                    .HasColumnName("promotion_price")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("促销价格");

                entity.Property(e => e.PromotionStartTime)
                    .HasColumnName("promotion_start_time")
                    .HasColumnType("datetime")
                    .HasComment("促销开始时间");

                entity.Property(e => e.PromotionType)
                    .HasColumnName("promotion_type")
                    .HasColumnType("int(1)")
                    .HasComment("促销类型：0->没有促销使用原价;1->使用促销价；2->使用会员价；3->使用阶梯价格；4->使用满减价格；5->限时购");

                entity.Property(e => e.PublishStatus)
                    .HasColumnName("publish_status")
                    .HasColumnType("int(1)")
                    .HasComment("上架状态：0->下架；1->上架");

                entity.Property(e => e.RecommandStatus)
                    .HasColumnName("recommand_status")
                    .HasColumnType("int(1)")
                    .HasComment("推荐状态；0->不推荐；1->推荐");

                entity.Property(e => e.Sale)
                    .HasColumnName("sale")
                    .HasColumnType("int(11)")
                    .HasComment("销量");

                entity.Property(e => e.ServiceIds)
                    .HasColumnName("service_ids")
                    .HasColumnType("varchar(64)")
                    .HasComment("以逗号分割的产品服务：1->无忧退货；2->快速退款；3->免费包邮")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)")
                    .HasComment("排序");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("int(11)")
                    .HasComment("库存");

                entity.Property(e => e.SubTitle)
                    .HasColumnName("sub_title")
                    .HasColumnType("varchar(255)")
                    .HasComment("副标题")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Unit)
                    .HasColumnName("unit")
                    .HasColumnType("varchar(16)")
                    .HasComment("单位")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UsePointLimit)
                    .HasColumnName("use_point_limit")
                    .HasColumnType("int(11)")
                    .HasComment("限制使用的积分数");

                entity.Property(e => e.VerifyStatus)
                    .HasColumnName("verify_status")
                    .HasColumnType("int(1)")
                    .HasComment("审核状态：0->未审核；1->审核通过");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("商品重量，默认为克");
            });

            modelBuilder.Entity<PmsProductAttribute>(entity =>
            {
                entity.ToTable("pms_product_attribute");

                entity.HasComment("商品属性参数表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.FilterType)
                    .HasColumnName("filter_type")
                    .HasColumnType("int(1)")
                    .HasComment("分类筛选样式：1->普通；1->颜色");

                entity.Property(e => e.HandAddStatus)
                    .HasColumnName("hand_add_status")
                    .HasColumnType("int(1)")
                    .HasComment("是否支持手动新增；0->不支持；1->支持");

                entity.Property(e => e.InputList)
                    .HasColumnName("input_list")
                    .HasColumnType("varchar(255)")
                    .HasComment("可选值列表，以逗号隔开")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.InputType)
                    .HasColumnName("input_type")
                    .HasColumnType("int(1)")
                    .HasComment("属性录入方式：0->手工录入；1->从列表中选取");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductAttributeCategoryId)
                    .HasColumnName("product_attribute_category_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.RelatedStatus)
                    .HasColumnName("related_status")
                    .HasColumnType("int(1)")
                    .HasComment("相同属性产品是否关联；0->不关联；1->关联");

                entity.Property(e => e.SearchType)
                    .HasColumnName("search_type")
                    .HasColumnType("int(1)")
                    .HasComment("检索类型；0->不需要进行检索；1->关键字检索；2->范围检索");

                entity.Property(e => e.SelectType)
                    .HasColumnName("select_type")
                    .HasColumnType("int(1)")
                    .HasComment("属性选择类型：0->唯一；1->单选；2->多选");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)")
                    .HasComment("排序字段：最高的可以单独上传图片");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)")
                    .HasComment("属性的类型；0->规格；1->参数");
            });

            modelBuilder.Entity<PmsProductAttributeCategory>(entity =>
            {
                entity.ToTable("pms_product_attribute_category");

                entity.HasComment("产品属性分类表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AttributeCount)
                    .HasColumnName("attribute_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("属性数量");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParamCount)
                    .HasColumnName("param_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("参数数量");
            });

            modelBuilder.Entity<PmsProductAttributeValue>(entity =>
            {
                entity.ToTable("pms_product_attribute_value");

                entity.HasComment("存储产品参数信息的表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ProductAttributeId)
                    .HasColumnName("product_attribute_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("varchar(64)")
                    .HasComment("手动添加规格或参数的值，参数单值，规格有多个时以逗号隔开")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PmsProductCategory>(entity =>
            {
                entity.ToTable("pms_product_category");

                entity.HasComment("产品分类");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text")
                    .HasComment("描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("varchar(255)")
                    .HasComment("图标")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Keywords)
                    .HasColumnName("keywords")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(1)")
                    .HasComment("分类级别：0->1级；1->2级");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NavStatus)
                    .HasColumnName("nav_status")
                    .HasColumnType("int(1)")
                    .HasComment("是否显示在导航栏：0->不显示；1->显示");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("上机分类的编号：0表示一级分类");

                entity.Property(e => e.ProductCount)
                    .HasColumnName("product_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductUnit)
                    .HasColumnName("product_unit")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ShowStatus)
                    .HasColumnName("show_status")
                    .HasColumnType("int(1)")
                    .HasComment("显示状态：0->不显示；1->显示");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PmsProductCategoryAttributeRelation>(entity =>
            {
                entity.ToTable("pms_product_category_attribute_relation");

                entity.HasComment("产品的分类和属性的关系表，用于设置分类筛选条件（只支持一级分类）");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ProductAttributeId)
                    .HasColumnName("product_attribute_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ProductCategoryId)
                    .HasColumnName("product_category_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<PmsProductFullReduction>(entity =>
            {
                entity.ToTable("pms_product_full_reduction");

                entity.HasComment("产品满减表(只针对同商品)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(11)");

                entity.Property(e => e.FullPrice)
                    .HasColumnName("full_price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ReducePrice)
                    .HasColumnName("reduce_price")
                    .HasColumnType("decimal(10,2)");
            });

            modelBuilder.Entity<PmsProductLadder>(entity =>
            {
                entity.ToTable("pms_product_ladder");

                entity.HasComment("产品阶梯价格表(只针对同商品)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("int(11)")
                    .HasComment("满足的商品数量");

                entity.Property(e => e.Discount)
                    .HasColumnName("discount")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("折扣");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("折后价格");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<PmsProductOperateLog>(entity =>
            {
                entity.ToTable("pms_product_operate_log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.GiftPointNew)
                    .HasColumnName("gift_point_new")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GiftPointOld)
                    .HasColumnName("gift_point_old")
                    .HasColumnType("int(11)")
                    .HasComment("赠送的积分");

                entity.Property(e => e.OperateMan)
                    .HasColumnName("operate_man")
                    .HasColumnType("varchar(64)")
                    .HasComment("操作人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PriceNew)
                    .HasColumnName("price_new")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.PriceOld)
                    .HasColumnName("price_old")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.SalePriceNew)
                    .HasColumnName("sale_price_new")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.SalePriceOld)
                    .HasColumnName("sale_price_old")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.UsePointLimitNew)
                    .HasColumnName("use_point_limit_new")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UsePointLimitOld)
                    .HasColumnName("use_point_limit_old")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<PmsProductVertifyRecord>(entity =>
            {
                entity.ToTable("pms_product_vertify_record");

                entity.HasComment("商品审核记录");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Detail)
                    .HasColumnName("detail")
                    .HasColumnType("varchar(255)")
                    .HasComment("反馈详情")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)");

                entity.Property(e => e.VertifyMan)
                    .HasColumnName("vertify_man")
                    .HasColumnType("varchar(64)")
                    .HasComment("审核人")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<PmsSkuStock>(entity =>
            {
                entity.ToTable("pms_sku_stock");

                entity.HasComment("sku的库存");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.LockStock)
                    .HasColumnName("lock_stock")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("锁定库存");

                entity.Property(e => e.LowStock)
                    .HasColumnName("low_stock")
                    .HasColumnType("int(11)")
                    .HasComment("预警库存");

                entity.Property(e => e.Pic)
                    .HasColumnName("pic")
                    .HasColumnType("varchar(255)")
                    .HasComment("展示图片")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(10,2)");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.PromotionPrice)
                    .HasColumnName("promotion_price")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("单品促销价格");

                entity.Property(e => e.Sale)
                    .HasColumnName("sale")
                    .HasColumnType("int(11)")
                    .HasComment("销量");

                entity.Property(e => e.SkuCode)
                    .IsRequired()
                    .HasColumnName("sku_code")
                    .HasColumnType("varchar(64)")
                    .HasComment("sku编码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SpData)
                    .HasColumnName("sp_data")
                    .HasColumnType("varchar(500)")
                    .HasComment("商品销售属性，json格式")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Stock)
                    .HasColumnName("stock")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("库存");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
