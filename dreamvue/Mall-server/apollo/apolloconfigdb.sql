/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

# Create Database
# ------------------------------------------------------------
CREATE DATABASE IF NOT EXISTS ApolloConfigDB DEFAULT CHARACTER SET = utf8mb4;

Use ApolloConfigDB;

# Dump of table app
# ------------------------------------------------------------

DROP TABLE IF EXISTS `App`;

CREATE TABLE `App` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '����',
  `AppId` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'AppID',
  `Name` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'Ӧ����',
  `OrgId` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����Id',
  `OrgName` varchar(64) NOT NULL DEFAULT 'default' COMMENT '��������',
  `OwnerName` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'ownerName',
  `OwnerEmail` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'ownerEmail',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `AppId` (`AppId`(191)),
  KEY `DataChange_LastTime` (`DataChange_LastTime`),
  KEY `IX_Name` (`Name`(191))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='Ӧ�ñ�';



# Dump of table appnamespace
# ------------------------------------------------------------

DROP TABLE IF EXISTS `AppNamespace`;

CREATE TABLE `AppNamespace` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '��������',
  `Name` varchar(32) NOT NULL DEFAULT '' COMMENT 'namespace���֣�ע�⣬��Ҫȫ��Ψһ',
  `AppId` varchar(32) NOT NULL DEFAULT '' COMMENT 'app id',
  `Format` varchar(32) NOT NULL DEFAULT 'properties' COMMENT 'namespace��format����',
  `IsPublic` bit(1) NOT NULL DEFAULT b'0' COMMENT 'namespace�Ƿ�Ϊ����',
  `Comment` varchar(64) NOT NULL DEFAULT '' COMMENT 'ע��',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT '' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `IX_AppId` (`AppId`),
  KEY `Name_AppId` (`Name`,`AppId`),
  KEY `DataChange_LastTime` (`DataChange_LastTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='Ӧ��namespace����';



# Dump of table audit
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Audit`;

CREATE TABLE `Audit` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '����',
  `EntityName` varchar(50) NOT NULL DEFAULT 'default' COMMENT '����',
  `EntityId` int(10) unsigned DEFAULT NULL COMMENT '��¼ID',
  `OpName` varchar(50) NOT NULL DEFAULT 'default' COMMENT '��������',
  `Comment` varchar(500) DEFAULT NULL COMMENT '��ע',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `DataChange_LastTime` (`DataChange_LastTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='��־��Ʊ�';



# Dump of table cluster
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Cluster`;

CREATE TABLE `Cluster` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '��������',
  `Name` varchar(32) NOT NULL DEFAULT '' COMMENT '��Ⱥ����',
  `AppId` varchar(32) NOT NULL DEFAULT '' COMMENT 'App id',
  `ParentClusterId` int(10) unsigned NOT NULL DEFAULT '0' COMMENT '��cluster',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT '' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `IX_AppId_Name` (`AppId`,`Name`),
  KEY `IX_ParentClusterId` (`ParentClusterId`),
  KEY `DataChange_LastTime` (`DataChange_LastTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='��Ⱥ';



# Dump of table commit
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Commit`;

CREATE TABLE `Commit` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '����',
  `ChangeSets` longtext NOT NULL COMMENT '�޸ı����',
  `AppId` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'AppID',
  `ClusterName` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'ClusterName',
  `NamespaceName` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'namespaceName',
  `Comment` varchar(500) DEFAULT NULL COMMENT '��ע',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `DataChange_LastTime` (`DataChange_LastTime`),
  KEY `AppId` (`AppId`(191)),
  KEY `ClusterName` (`ClusterName`(191)),
  KEY `NamespaceName` (`NamespaceName`(191))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='commit ��ʷ��';

# Dump of table grayreleaserule
# ------------------------------------------------------------

DROP TABLE IF EXISTS `GrayReleaseRule`;

CREATE TABLE `GrayReleaseRule` (
  `Id` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '����',
  `AppId` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'AppID',
  `ClusterName` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'Cluster Name',
  `NamespaceName` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'Namespace Name',
  `BranchName` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'branch name',
  `Rules` varchar(16000) DEFAULT '[]' COMMENT '�Ҷȹ���',
  `ReleaseId` int(11) unsigned NOT NULL DEFAULT '0' COMMENT '�Ҷȶ�Ӧ��release',
  `BranchStatus` tinyint(2) DEFAULT '1' COMMENT '�Ҷȷ�֧״̬: 0:ɾ����֧,1:����ʹ�õĹ��� 2��ȫ������',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `DataChange_LastTime` (`DataChange_LastTime`),
  KEY `IX_Namespace` (`AppId`,`ClusterName`,`NamespaceName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='�Ҷȹ����';


# Dump of table instance
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Instance`;

CREATE TABLE `Instance` (
  `Id` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '����Id',
  `AppId` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'AppID',
  `ClusterName` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'ClusterName',
  `DataCenter` varchar(64) NOT NULL DEFAULT 'default' COMMENT 'Data Center Name',
  `Ip` varchar(32) NOT NULL DEFAULT '' COMMENT 'instance ip',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_UNIQUE_KEY` (`AppId`,`ClusterName`,`Ip`,`DataCenter`),
  KEY `IX_IP` (`Ip`),
  KEY `IX_DataChange_LastTime` (`DataChange_LastTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='ʹ�����õ�Ӧ��ʵ��';



# Dump of table instanceconfig
# ------------------------------------------------------------

DROP TABLE IF EXISTS `InstanceConfig`;

CREATE TABLE `InstanceConfig` (
  `Id` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '����Id',
  `InstanceId` int(11) unsigned DEFAULT NULL COMMENT 'Instance Id',
  `ConfigAppId` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'Config App Id',
  `ConfigClusterName` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'Config Cluster Name',
  `ConfigNamespaceName` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'Config Namespace Name',
  `ReleaseKey` varchar(64) NOT NULL DEFAULT '' COMMENT '������Key',
  `ReleaseDeliveryTime` timestamp NULL DEFAULT NULL COMMENT '���û�ȡʱ��',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_UNIQUE_KEY` (`InstanceId`,`ConfigAppId`,`ConfigNamespaceName`),
  KEY `IX_ReleaseKey` (`ReleaseKey`),
  KEY `IX_DataChange_LastTime` (`DataChange_LastTime`),
  KEY `IX_Valid_Namespace` (`ConfigAppId`,`ConfigClusterName`,`ConfigNamespaceName`,`DataChange_LastTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='Ӧ��ʵ����������Ϣ';



# Dump of table item
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Item`;

CREATE TABLE `Item` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '����Id',
  `NamespaceId` int(10) unsigned NOT NULL DEFAULT '0' COMMENT '��ȺNamespaceId',
  `Key` varchar(128) NOT NULL DEFAULT 'default' COMMENT '������Key',
  `Value` longtext NOT NULL COMMENT '������ֵ',
  `Comment` varchar(1024) DEFAULT '' COMMENT 'ע��',
  `LineNum` int(10) unsigned DEFAULT '0' COMMENT '�к�',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `IX_GroupId` (`NamespaceId`),
  KEY `DataChange_LastTime` (`DataChange_LastTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='������Ŀ';



# Dump of table namespace
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Namespace`;

CREATE TABLE `Namespace` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '��������',
  `AppId` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'AppID',
  `ClusterName` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'Cluster Name',
  `NamespaceName` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'Namespace Name',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `AppId_ClusterName_NamespaceName` (`AppId`(191),`ClusterName`(191),`NamespaceName`(191)),
  KEY `DataChange_LastTime` (`DataChange_LastTime`),
  KEY `IX_NamespaceName` (`NamespaceName`(191))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='�����ռ�';



# Dump of table namespacelock
# ------------------------------------------------------------

DROP TABLE IF EXISTS `NamespaceLock`;

CREATE TABLE `NamespaceLock` (
  `Id` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '����id',
  `NamespaceId` int(10) unsigned NOT NULL DEFAULT '0' COMMENT '��ȺNamespaceId',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT 'default' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  `IsDeleted` bit(1) DEFAULT b'0' COMMENT '��ɾ��',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_NamespaceId` (`NamespaceId`),
  KEY `DataChange_LastTime` (`DataChange_LastTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='namespace�ı༭��';



# Dump of table release
# ------------------------------------------------------------

DROP TABLE IF EXISTS `Release`;

CREATE TABLE `Release` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '��������',
  `ReleaseKey` varchar(64) NOT NULL DEFAULT '' COMMENT '������Key',
  `Name` varchar(64) NOT NULL DEFAULT 'default' COMMENT '��������',
  `Comment` varchar(256) DEFAULT NULL COMMENT '����˵��',
  `AppId` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'AppID',
  `ClusterName` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'ClusterName',
  `NamespaceName` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'namespaceName',
  `Configurations` longtext NOT NULL COMMENT '��������',
  `IsAbandoned` bit(1) NOT NULL DEFAULT b'0' COMMENT '�Ƿ����',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `AppId_ClusterName_GroupName` (`AppId`(191),`ClusterName`(191),`NamespaceName`(191)),
  KEY `DataChange_LastTime` (`DataChange_LastTime`),
  KEY `IX_ReleaseKey` (`ReleaseKey`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='����';


# Dump of table releasehistory
# ------------------------------------------------------------

DROP TABLE IF EXISTS `ReleaseHistory`;

CREATE TABLE `ReleaseHistory` (
  `Id` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '����Id',
  `AppId` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'AppID',
  `ClusterName` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'ClusterName',
  `NamespaceName` varchar(32) NOT NULL DEFAULT 'default' COMMENT 'namespaceName',
  `BranchName` varchar(32) NOT NULL DEFAULT 'default' COMMENT '������֧��',
  `ReleaseId` int(11) unsigned NOT NULL DEFAULT '0' COMMENT '������Release Id',
  `PreviousReleaseId` int(11) unsigned NOT NULL DEFAULT '0' COMMENT 'ǰһ�η�����ReleaseId',
  `Operation` tinyint(3) unsigned NOT NULL DEFAULT '0' COMMENT '�������ͣ�0: ��ͨ������1: �ع���2: �Ҷȷ�����3: �Ҷȹ�����£�4: �ҶȺϲ�������֧������5: ����֧�����Ҷ��Զ�������6: ����֧�ع��Ҷ��Զ�������7: �����Ҷ�',
  `OperationContext` longtext NOT NULL COMMENT '������������Ϣ',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `IX_Namespace` (`AppId`,`ClusterName`,`NamespaceName`,`BranchName`),
  KEY `IX_ReleaseId` (`ReleaseId`),
  KEY `IX_DataChange_LastTime` (`DataChange_LastTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='������ʷ';


# Dump of table releasemessage
# ------------------------------------------------------------

DROP TABLE IF EXISTS `ReleaseMessage`;

CREATE TABLE `ReleaseMessage` (
  `Id` int(11) unsigned NOT NULL AUTO_INCREMENT COMMENT '��������',
  `Message` varchar(1024) NOT NULL DEFAULT '' COMMENT '��������Ϣ����',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `DataChange_LastTime` (`DataChange_LastTime`),
  KEY `IX_Message` (`Message`(191))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='������Ϣ';



# Dump of table serverconfig
# ------------------------------------------------------------

DROP TABLE IF EXISTS `ServerConfig`;

CREATE TABLE `ServerConfig` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '����Id',
  `Key` varchar(64) NOT NULL DEFAULT 'default' COMMENT '������Key',
  `Cluster` varchar(32) NOT NULL DEFAULT 'default' COMMENT '���ö�Ӧ�ļ�Ⱥ��defaultΪ������ض��ļ�Ⱥ',
  `Value` varchar(2048) NOT NULL DEFAULT 'default' COMMENT '������ֵ',
  `Comment` varchar(1024) DEFAULT '' COMMENT 'ע��',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `IX_Key` (`Key`),
  KEY `DataChange_LastTime` (`DataChange_LastTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='���÷�����������';

# Dump of table accesskey
# ------------------------------------------------------------

DROP TABLE IF EXISTS `AccessKey`;

CREATE TABLE `AccessKey` (
  `Id` int(10) unsigned NOT NULL AUTO_INCREMENT COMMENT '��������',
  `AppId` varchar(500) NOT NULL DEFAULT 'default' COMMENT 'AppID',
  `Secret` varchar(128) NOT NULL DEFAULT '' COMMENT 'Secret',
  `IsEnabled` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: enabled, 0: disabled',
  `IsDeleted` bit(1) NOT NULL DEFAULT b'0' COMMENT '1: deleted, 0: normal',
  `DataChange_CreatedBy` varchar(32) NOT NULL DEFAULT 'default' COMMENT '����������ǰ׺',
  `DataChange_CreatedTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '����ʱ��',
  `DataChange_LastModifiedBy` varchar(32) NOT NULL DEFAULT '' COMMENT '����޸�������ǰ׺',
  `DataChange_LastTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '����޸�ʱ��',
  PRIMARY KEY (`Id`),
  KEY `AppId` (`AppId`(191)),
  KEY `DataChange_LastTime` (`DataChange_LastTime`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COMMENT='������Կ';

# Config
# ------------------------------------------------------------
INSERT INTO `ServerConfig` (`Key`, `Cluster`, `Value`, `Comment`)
VALUES
    ('eureka.service.url', 'default', 'http://localhost:8080/eureka/', 'Eureka����Url�����service��Ӣ�Ķ��ŷָ�'),
    ('namespace.lock.switch', 'default', 'false', 'һ�η���ֻ����һ�����޸Ŀ���'),
    ('item.value.length.limit', 'default', '20000', 'item value��󳤶�����'),
    ('config-service.cache.enabled', 'default', 'false', 'ConfigService�Ƿ������棬��������������ܣ����ǻ������ڴ����ģ�'),
    ('item.key.length.limit', 'default', '128', 'item key ��󳤶�����');

# Sample Data
# ------------------------------------------------------------
INSERT INTO `App` (`AppId`, `Name`, `OrgId`, `OrgName`, `OwnerName`, `OwnerEmail`)
VALUES
	('SampleApp', 'Sample App', 'TEST1', '��������1', 'apollo', 'apollo@acme.com');

INSERT INTO `AppNamespace` (`Name`, `AppId`, `Format`, `IsPublic`, `Comment`)
VALUES
	('application', 'SampleApp', 'properties', 0, 'default app namespace');

INSERT INTO `Cluster` (`Name`, `AppId`)
VALUES
	('default', 'SampleApp');

INSERT INTO `Namespace` (`Id`, `AppId`, `ClusterName`, `NamespaceName`)
VALUES
	(1, 'SampleApp', 'default', 'application');


INSERT INTO `Item` (`NamespaceId`, `Key`, `Value`, `Comment`, `LineNum`)
VALUES
	(1, 'timeout', '100', 'sample timeout����', 1);

INSERT INTO `Release` (`ReleaseKey`, `Name`, `Comment`, `AppId`, `ClusterName`, `NamespaceName`, `Configurations`)
VALUES
	('20161009155425-d3a0749c6e20bc15', '20161009155424-release', 'Sample����', 'SampleApp', 'default', 'application', '{\"timeout\":\"100\"}');

INSERT INTO `ReleaseHistory` (`AppId`, `ClusterName`, `NamespaceName`, `BranchName`, `ReleaseId`, `PreviousReleaseId`, `Operation`, `OperationContext`, `DataChange_CreatedBy`, `DataChange_LastModifiedBy`)
VALUES
  ('SampleApp', 'default', 'application', 'default', 1, 0, 0, '{}', 'apollo', 'apollo');

INSERT INTO `ReleaseMessage` (`Message`)
VALUES
	('SampleApp+default+application');

/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;