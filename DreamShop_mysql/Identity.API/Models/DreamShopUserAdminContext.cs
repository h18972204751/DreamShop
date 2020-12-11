using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Identity.API.Models
{
    public partial class DreamShopUserAdminContext : DbContext
    {
        public DreamShopUserAdminContext()
        {
        }

        public DreamShopUserAdminContext(DbContextOptions<DreamShopUserAdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UmsAdmin> UmsAdmin { get; set; }
        public virtual DbSet<UmsAdminLoginLog> UmsAdminLoginLog { get; set; }
        public virtual DbSet<UmsAdminPermissionRelation> UmsAdminPermissionRelation { get; set; }
        public virtual DbSet<UmsAdminRoleRelation> UmsAdminRoleRelation { get; set; }
        public virtual DbSet<UmsGrowthChangeHistory> UmsGrowthChangeHistory { get; set; }
        public virtual DbSet<UmsIntegrationChangeHistory> UmsIntegrationChangeHistory { get; set; }
        public virtual DbSet<UmsIntegrationConsumeSetting> UmsIntegrationConsumeSetting { get; set; }
        public virtual DbSet<UmsMember> UmsMember { get; set; }
        public virtual DbSet<UmsMemberLevel> UmsMemberLevel { get; set; }
        public virtual DbSet<UmsMemberLoginLog> UmsMemberLoginLog { get; set; }
        public virtual DbSet<UmsMemberMemberTagRelation> UmsMemberMemberTagRelation { get; set; }
        public virtual DbSet<UmsMemberProductCategoryRelation> UmsMemberProductCategoryRelation { get; set; }
        public virtual DbSet<UmsMemberReceiveAddress> UmsMemberReceiveAddress { get; set; }
        public virtual DbSet<UmsMemberRuleSetting> UmsMemberRuleSetting { get; set; }
        public virtual DbSet<UmsMemberStatisticsInfo> UmsMemberStatisticsInfo { get; set; }
        public virtual DbSet<UmsMemberTag> UmsMemberTag { get; set; }
        public virtual DbSet<UmsMemberTask> UmsMemberTask { get; set; }
        public virtual DbSet<UmsMenu> UmsMenu { get; set; }
        public virtual DbSet<UmsPermission> UmsPermission { get; set; }
        public virtual DbSet<UmsResource> UmsResource { get; set; }
        public virtual DbSet<UmsResourceCategory> UmsResourceCategory { get; set; }
        public virtual DbSet<UmsRole> UmsRole { get; set; }
        public virtual DbSet<UmsRoleMenuRelation> UmsRoleMenuRelation { get; set; }
        public virtual DbSet<UmsRolePermissionRelation> UmsRolePermissionRelation { get; set; }
        public virtual DbSet<UmsRoleResourceRelation> UmsRoleResourceRelation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=49.235.230.16;userid=root;pwd=Wei19960705.;port=3306;database=dreamshop.useradmin;sslmode=none", x => x.ServerVersion("5.7.24-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UmsAdmin>(entity =>
            {
                entity.ToTable("ums_admin");

                entity.HasComment("后台用户表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)")
                    .HasComment("邮箱")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("varchar(500)")
                    .HasComment("头像")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LoginTime)
                    .HasColumnName("login_time")
                    .HasColumnType("datetime")
                    .HasComment("最后登录时间");

                entity.Property(e => e.NickName)
                    .HasColumnName("nick_name")
                    .HasColumnType("varchar(200)")
                    .HasComment("昵称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(500)")
                    .HasComment("备注信息")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("帐号启用状态：0->禁用；1->启用");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UmsAdminLoginLog>(entity =>
            {
                entity.ToTable("ums_admin_login_log");

                entity.HasComment("后台用户登录日志表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserAgent)
                    .HasColumnName("user_agent")
                    .HasColumnType("varchar(100)")
                    .HasComment("浏览器登录类型")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UmsAdminPermissionRelation>(entity =>
            {
                entity.ToTable("ums_admin_permission_relation");

                entity.HasComment("后台用户和权限关系表(除角色中定义的权限以外的加减权限)");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)");
            });

            modelBuilder.Entity<UmsAdminRoleRelation>(entity =>
            {
                entity.ToTable("ums_admin_role_relation");

                entity.HasComment("后台用户和角色关系表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AdminId)
                    .HasColumnName("admin_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<UmsGrowthChangeHistory>(entity =>
            {
                entity.ToTable("ums_growth_change_history");

                entity.HasComment("成长值变化历史记录表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ChangeCount)
                    .HasColumnName("change_count")
                    .HasColumnType("int(11)")
                    .HasComment("积分改变数量");

                entity.Property(e => e.ChangeType)
                    .HasColumnName("change_type")
                    .HasColumnType("int(1)")
                    .HasComment("改变类型：0->增加；1->减少");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.MemberId)
                    .HasColumnName("member_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.OperateMan)
                    .HasColumnName("operate_man")
                    .HasColumnType("varchar(100)")
                    .HasComment("操作人员")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OperateNote)
                    .HasColumnName("operate_note")
                    .HasColumnType("varchar(200)")
                    .HasComment("操作备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SourceType)
                    .HasColumnName("source_type")
                    .HasColumnType("int(1)")
                    .HasComment("积分来源：0->购物；1->管理员修改");
            });

            modelBuilder.Entity<UmsIntegrationChangeHistory>(entity =>
            {
                entity.ToTable("ums_integration_change_history");

                entity.HasComment("积分变化历史记录表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ChangeCount)
                    .HasColumnName("change_count")
                    .HasColumnType("int(11)")
                    .HasComment("积分改变数量");

                entity.Property(e => e.ChangeType)
                    .HasColumnName("change_type")
                    .HasColumnType("int(1)")
                    .HasComment("改变类型：0->增加；1->减少");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.MemberId)
                    .HasColumnName("member_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.OperateMan)
                    .HasColumnName("operate_man")
                    .HasColumnType("varchar(100)")
                    .HasComment("操作人员")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.OperateNote)
                    .HasColumnName("operate_note")
                    .HasColumnType("varchar(200)")
                    .HasComment("操作备注")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SourceType)
                    .HasColumnName("source_type")
                    .HasColumnType("int(1)")
                    .HasComment("积分来源：0->购物；1->管理员修改");
            });

            modelBuilder.Entity<UmsIntegrationConsumeSetting>(entity =>
            {
                entity.ToTable("ums_integration_consume_setting");

                entity.HasComment("积分消费设置");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CouponStatus)
                    .HasColumnName("coupon_status")
                    .HasColumnType("int(1)")
                    .HasComment("是否可以和优惠券同用；0->不可以；1->可以");

                entity.Property(e => e.DeductionPerAmount)
                    .HasColumnName("deduction_per_amount")
                    .HasColumnType("int(11)")
                    .HasComment("每一元需要抵扣的积分数量");

                entity.Property(e => e.MaxPercentPerOrder)
                    .HasColumnName("max_percent_per_order")
                    .HasColumnType("int(11)")
                    .HasComment("每笔订单最高抵用百分比");

                entity.Property(e => e.UseUnit)
                    .HasColumnName("use_unit")
                    .HasColumnType("int(11)")
                    .HasComment("每次使用积分最小单位100");
            });

            modelBuilder.Entity<UmsMember>(entity =>
            {
                entity.ToTable("ums_member");

                entity.HasComment("会员表");

                entity.HasIndex(e => e.Phone)
                    .HasName("idx_phone")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("idx_username")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date")
                    .HasComment("生日");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(64)")
                    .HasComment("所做城市")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("注册时间");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("int(1)")
                    .HasComment("性别：0->未知；1->男；2->女");

                entity.Property(e => e.Growth)
                    .HasColumnName("growth")
                    .HasColumnType("int(11)")
                    .HasComment("成长值");

                entity.Property(e => e.HistoryIntegration)
                    .HasColumnName("history_integration")
                    .HasColumnType("int(11)")
                    .HasComment("历史积分数量");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("varchar(500)")
                    .HasComment("头像")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Integration)
                    .HasColumnName("integration")
                    .HasColumnType("int(11)")
                    .HasComment("积分");

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasColumnType("varchar(100)")
                    .HasComment("职业")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LuckeyCount)
                    .HasColumnName("luckey_count")
                    .HasColumnType("int(11)")
                    .HasComment("剩余抽奖次数");

                entity.Property(e => e.MemberLevelId)
                    .HasColumnName("member_level_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Nickname)
                    .HasColumnName("nickname")
                    .HasColumnType("varchar(64)")
                    .HasComment("昵称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(64)")
                    .HasComment("密码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PersonalizedSignature)
                    .HasColumnName("personalized_signature")
                    .HasColumnType("varchar(200)")
                    .HasComment("个性签名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasColumnType("varchar(64)")
                    .HasComment("手机号码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.SourceType)
                    .HasColumnName("source_type")
                    .HasColumnType("int(1)")
                    .HasComment("用户来源");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)")
                    .HasComment("帐号启用状态:0->禁用；1->启用");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(64)")
                    .HasComment("用户名")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UmsMemberLevel>(entity =>
            {
                entity.ToTable("ums_member_level");

                entity.HasComment("会员等级表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CommentGrowthPoint)
                    .HasColumnName("comment_growth_point")
                    .HasColumnType("int(11)")
                    .HasComment("每次评价获取的成长值");

                entity.Property(e => e.DefaultStatus)
                    .HasColumnName("default_status")
                    .HasColumnType("int(1)")
                    .HasComment("是否为默认等级：0->不是；1->是");

                entity.Property(e => e.FreeFreightPoint)
                    .HasColumnName("free_freight_point")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("免运费标准");

                entity.Property(e => e.GrowthPoint)
                    .HasColumnName("growth_point")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Note)
                    .HasColumnName("note")
                    .HasColumnType("varchar(200)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PriviledgeBirthday)
                    .HasColumnName("priviledge_birthday")
                    .HasColumnType("int(1)")
                    .HasComment("是否有生日特权");

                entity.Property(e => e.PriviledgeComment)
                    .HasColumnName("priviledge_comment")
                    .HasColumnType("int(1)")
                    .HasComment("是否有评论获奖励特权");

                entity.Property(e => e.PriviledgeFreeFreight)
                    .HasColumnName("priviledge_free_freight")
                    .HasColumnType("int(1)")
                    .HasComment("是否有免邮特权");

                entity.Property(e => e.PriviledgeMemberPrice)
                    .HasColumnName("priviledge_member_price")
                    .HasColumnType("int(1)")
                    .HasComment("是否有会员价格特权");

                entity.Property(e => e.PriviledgePromotion)
                    .HasColumnName("priviledge_promotion")
                    .HasColumnType("int(1)")
                    .HasComment("是否有专享活动特权");

                entity.Property(e => e.PriviledgeSignIn)
                    .HasColumnName("priviledge_sign_in")
                    .HasColumnType("int(1)")
                    .HasComment("是否有签到特权");
            });

            modelBuilder.Entity<UmsMemberLoginLog>(entity =>
            {
                entity.ToTable("ums_member_login_log");

                entity.HasComment("会员登录记录");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LoginType)
                    .HasColumnName("login_type")
                    .HasColumnType("int(1)")
                    .HasComment("登录类型：0->PC；1->android;2->ios;3->小程序");

                entity.Property(e => e.MemberId)
                    .HasColumnName("member_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UmsMemberMemberTagRelation>(entity =>
            {
                entity.ToTable("ums_member_member_tag_relation");

                entity.HasComment("用户和标签关系表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.MemberId)
                    .HasColumnName("member_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.TagId)
                    .HasColumnName("tag_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<UmsMemberProductCategoryRelation>(entity =>
            {
                entity.ToTable("ums_member_product_category_relation");

                entity.HasComment("会员与产品分类关系表（用户喜欢的分类）");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.MemberId)
                    .HasColumnName("member_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ProductCategoryId)
                    .HasColumnName("product_category_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<UmsMemberReceiveAddress>(entity =>
            {
                entity.ToTable("ums_member_receive_address");

                entity.HasComment("会员收货地址表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasColumnType("varchar(100)")
                    .HasComment("城市")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.DefaultStatus)
                    .HasColumnName("default_status")
                    .HasColumnType("int(1)")
                    .HasComment("是否为默认");

                entity.Property(e => e.DetailAddress)
                    .HasColumnName("detail_address")
                    .HasColumnType("varchar(128)")
                    .HasComment("详细地址(街道)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.MemberId)
                    .HasColumnName("member_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasComment("收货人名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnName("phone_number")
                    .HasColumnType("varchar(64)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PostCode)
                    .HasColumnName("post_code")
                    .HasColumnType("varchar(100)")
                    .HasComment("邮政编码")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Province)
                    .HasColumnName("province")
                    .HasColumnType("varchar(100)")
                    .HasComment("省份/直辖市")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Region)
                    .HasColumnName("region")
                    .HasColumnType("varchar(100)")
                    .HasComment("区")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UmsMemberRuleSetting>(entity =>
            {
                entity.ToTable("ums_member_rule_setting");

                entity.HasComment("会员积分成长规则表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ConsumePerPoint)
                    .HasColumnName("consume_per_point")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("每消费多少元获取1个点");

                entity.Property(e => e.ContinueSignDay)
                    .HasColumnName("continue_sign_day")
                    .HasColumnType("int(11)")
                    .HasComment("连续签到天数");

                entity.Property(e => e.ContinueSignPoint)
                    .HasColumnName("continue_sign_point")
                    .HasColumnType("int(11)")
                    .HasComment("连续签到赠送数量");

                entity.Property(e => e.LowOrderAmount)
                    .HasColumnName("low_order_amount")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("最低获取点数的订单金额");

                entity.Property(e => e.MaxPointPerOrder)
                    .HasColumnName("max_point_per_order")
                    .HasColumnType("int(11)")
                    .HasComment("每笔订单最高获取点数");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)")
                    .HasComment("类型：0->积分规则；1->成长值规则");
            });

            modelBuilder.Entity<UmsMemberStatisticsInfo>(entity =>
            {
                entity.ToTable("ums_member_statistics_info");

                entity.HasComment("会员统计信息");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AttendCount)
                    .HasColumnName("attend_count")
                    .HasColumnType("int(11)")
                    .HasComment("关注数量");

                entity.Property(e => e.CollectCommentCount)
                    .HasColumnName("collect_comment_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CollectProductCount)
                    .HasColumnName("collect_product_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CollectSubjectCount)
                    .HasColumnName("collect_subject_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CollectTopicCount)
                    .HasColumnName("collect_topic_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CommentCount)
                    .HasColumnName("comment_count")
                    .HasColumnType("int(11)")
                    .HasComment("评价数");

                entity.Property(e => e.ConsumeAmount)
                    .HasColumnName("consume_amount")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("累计消费金额");

                entity.Property(e => e.CouponCount)
                    .HasColumnName("coupon_count")
                    .HasColumnType("int(11)")
                    .HasComment("优惠券数量");

                entity.Property(e => e.FansCount)
                    .HasColumnName("fans_count")
                    .HasColumnType("int(11)")
                    .HasComment("粉丝数量");

                entity.Property(e => e.InviteFriendCount)
                    .HasColumnName("invite_friend_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LoginCount)
                    .HasColumnName("login_count")
                    .HasColumnType("int(11)")
                    .HasComment("登录次数");

                entity.Property(e => e.MemberId)
                    .HasColumnName("member_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.OrderCount)
                    .HasColumnName("order_count")
                    .HasColumnType("int(11)")
                    .HasComment("订单数量");

                entity.Property(e => e.RecentOrderTime)
                    .HasColumnName("recent_order_time")
                    .HasColumnType("datetime")
                    .HasComment("最后一次下订单时间");

                entity.Property(e => e.ReturnOrderCount)
                    .HasColumnName("return_order_count")
                    .HasColumnType("int(11)")
                    .HasComment("退货数量");
            });

            modelBuilder.Entity<UmsMemberTag>(entity =>
            {
                entity.ToTable("ums_member_tag");

                entity.HasComment("用户标签表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.FinishOrderAmount)
                    .HasColumnName("finish_order_amount")
                    .HasColumnType("decimal(10,2)")
                    .HasComment("自动打标签完成订单金额");

                entity.Property(e => e.FinishOrderCount)
                    .HasColumnName("finish_order_count")
                    .HasColumnType("int(11)")
                    .HasComment("自动打标签完成订单数量");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UmsMemberTask>(entity =>
            {
                entity.ToTable("ums_member_task");

                entity.HasComment("会员任务表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Growth)
                    .HasColumnName("growth")
                    .HasColumnType("int(11)")
                    .HasComment("赠送成长值");

                entity.Property(e => e.Intergration)
                    .HasColumnName("intergration")
                    .HasColumnType("int(11)")
                    .HasComment("赠送积分");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)")
                    .HasComment("任务类型：0->新手任务；1->日常任务");
            });

            modelBuilder.Entity<UmsMenu>(entity =>
            {
                entity.ToTable("ums_menu");

                entity.HasComment("后台菜单表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Hidden)
                    .HasColumnName("hidden")
                    .HasColumnType("int(1)")
                    .HasComment("前端隐藏");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("varchar(200)")
                    .HasComment("前端图标")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(4)")
                    .HasComment("菜单级数");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasComment("前端名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("父级ID");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(4)")
                    .HasComment("菜单排序");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasColumnType("varchar(100)")
                    .HasComment("菜单名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UmsPermission>(entity =>
            {
                entity.ToTable("ums_permission");

                entity.HasComment("后台用户权限表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("varchar(500)")
                    .HasComment("图标")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasComment("名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("bigint(20)")
                    .HasComment("父级权限id");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)")
                    .HasComment("排序");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)")
                    .HasComment("启用状态；0->禁用；1->启用");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(1)")
                    .HasComment("权限类型：0->目录；1->菜单；2->按钮（接口绑定权限）");

                entity.Property(e => e.Uri)
                    .HasColumnName("uri")
                    .HasColumnType("varchar(200)")
                    .HasComment("前端资源路径")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("varchar(200)")
                    .HasComment("权限值")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UmsResource>(entity =>
            {
                entity.ToTable("ums_resource");

                entity.HasComment("后台资源表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("资源分类ID");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(500)")
                    .HasComment("描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)")
                    .HasComment("资源名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasColumnType("varchar(200)")
                    .HasComment("资源URL")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<UmsResourceCategory>(entity =>
            {
                entity.ToTable("ums_resource_category");

                entity.HasComment("资源分类表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(200)")
                    .HasComment("分类名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(4)")
                    .HasComment("排序");
            });

            modelBuilder.Entity<UmsRole>(entity =>
            {
                entity.ToTable("ums_role");

                entity.HasComment("后台用户角色表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AdminCount)
                    .HasColumnName("admin_count")
                    .HasColumnType("int(11)")
                    .HasComment("后台用户数量");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("create_time")
                    .HasColumnType("datetime")
                    .HasComment("创建时间");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("varchar(500)")
                    .HasComment("描述")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)")
                    .HasComment("名称")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.Sort)
                    .HasColumnName("sort")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'1'")
                    .HasComment("启用状态：0->禁用；1->启用");
            });

            modelBuilder.Entity<UmsRoleMenuRelation>(entity =>
            {
                entity.ToTable("ums_role_menu_relation");

                entity.HasComment("后台角色菜单关系表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.MenuId)
                    .HasColumnName("menu_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("菜单ID");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("角色ID");
            });

            modelBuilder.Entity<UmsRolePermissionRelation>(entity =>
            {
                entity.ToTable("ums_role_permission_relation");

                entity.HasComment("后台用户角色和权限关系表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.PermissionId)
                    .HasColumnName("permission_id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<UmsRoleResourceRelation>(entity =>
            {
                entity.ToTable("ums_role_resource_relation");

                entity.HasComment("后台角色资源关系表");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.ResourceId)
                    .HasColumnName("resource_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("资源ID");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasColumnType("bigint(20)")
                    .HasComment("角色ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
