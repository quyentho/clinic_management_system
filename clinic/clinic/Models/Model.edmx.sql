
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/09/2020 18:17:12
-- Generated from EDMX file: D:\My Folder\Programming\C#\clinic_management_system\clinic\clinic\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [clinic];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__prescript__bill___4CA06362]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[prescription] DROP CONSTRAINT [FK__prescript__bill___4CA06362];
GO
IF OBJECT_ID(N'[dbo].[FK__prescript__medic__4D94879B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[prescription] DROP CONSTRAINT [FK__prescript__medic__4D94879B];
GO
IF OBJECT_ID(N'[dbo].[FK__service_d__bill___5070F446]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[services_in_bill] DROP CONSTRAINT [FK__service_d__bill___5070F446];
GO
IF OBJECT_ID(N'[dbo].[FK__service_d__servi__5165187F]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[services_in_bill] DROP CONSTRAINT [FK__service_d__servi__5165187F];
GO
IF OBJECT_ID(N'[dbo].[FK_account_permission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[account] DROP CONSTRAINT [FK_account_permission];
GO
IF OBJECT_ID(N'[dbo].[FK_bill_patient]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[bill] DROP CONSTRAINT [FK_bill_patient];
GO
IF OBJECT_ID(N'[dbo].[FK_bill_staff]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[bill] DROP CONSTRAINT [FK_bill_staff];
GO
IF OBJECT_ID(N'[dbo].[FK_staff_account]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[account] DROP CONSTRAINT [FK_staff_account];
GO
IF OBJECT_ID(N'[dbo].[FK_staff_permission]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[staff] DROP CONSTRAINT [FK_staff_permission];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[account]', 'U') IS NOT NULL
    DROP TABLE [dbo].[account];
GO
IF OBJECT_ID(N'[dbo].[bill]', 'U') IS NOT NULL
    DROP TABLE [dbo].[bill];
GO
IF OBJECT_ID(N'[dbo].[clinic_service]', 'U') IS NOT NULL
    DROP TABLE [dbo].[clinic_service];
GO
IF OBJECT_ID(N'[dbo].[medicine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[medicine];
GO
IF OBJECT_ID(N'[dbo].[patient]', 'U') IS NOT NULL
    DROP TABLE [dbo].[patient];
GO
IF OBJECT_ID(N'[dbo].[permission]', 'U') IS NOT NULL
    DROP TABLE [dbo].[permission];
GO
IF OBJECT_ID(N'[dbo].[prescription]', 'U') IS NOT NULL
    DROP TABLE [dbo].[prescription];
GO
IF OBJECT_ID(N'[dbo].[services_in_bill]', 'U') IS NOT NULL
    DROP TABLE [dbo].[services_in_bill];
GO
IF OBJECT_ID(N'[dbo].[staff]', 'U') IS NOT NULL
    DROP TABLE [dbo].[staff];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'accounts'
CREATE TABLE [dbo].[accounts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [staff_id] int  NOT NULL,
    [username] varchar(15)  NOT NULL,
    [pass] varchar(50)  NOT NULL,
    [permission_id] int  NOT NULL,
    [is_active] bit  NOT NULL
);
GO

-- Creating table 'bills'
CREATE TABLE [dbo].[bills] (
    [id] int IDENTITY(1,1) NOT NULL,
    [patient_id] int  NOT NULL,
    [created_at] datetime  NOT NULL,
    [staff_created] int  NOT NULL,
    [total_money] bigint  NOT NULL,
    [is_paid] bit  NOT NULL
);
GO

-- Creating table 'clinic_service'
CREATE TABLE [dbo].[clinic_service] (
    [id] int IDENTITY(1,1) NOT NULL,
    [service_name] nvarchar(50)  NOT NULL,
    [price] decimal(10,2)  NOT NULL,
    [is_active] bit  NULL
);
GO

-- Creating table 'patients'
CREATE TABLE [dbo].[patients] (
    [id] int IDENTITY(1,1) NOT NULL,
    [patient_name] nvarchar(50)  NOT NULL,
    [age] int  NULL,
    [gender] nvarchar(10)  NULL,
    [phone_number] varchar(15)  NULL
);
GO

-- Creating table 'permissions'
CREATE TABLE [dbo].[permissions] (
    [id] int IDENTITY(1,1) NOT NULL,
    [position_name] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'prescriptions'
CREATE TABLE [dbo].[prescriptions] (
    [bill_id] int  NOT NULL,
    [medicine_id] int  NOT NULL,
    [quantity_indicated] int  NOT NULL,
    [description] nvarchar(max)  NULL
);
GO

-- Creating table 'staffs'
CREATE TABLE [dbo].[staffs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [full_name] nvarchar(50)  NOT NULL,
    [date_of_birdth] varchar(50)  NULL,
    [phone_number] varchar(15)  NOT NULL,
    [salary] bigint  NOT NULL,
    [is_still_working] bit  NOT NULL,
    [permission_id] int  NOT NULL
);
GO

-- Creating table 'medicines'
CREATE TABLE [dbo].[medicines] (
    [id] int IDENTITY(1,1) NOT NULL,
    [medicine_name] nvarchar(50)  NOT NULL,
    [quantity_in_sale_unit] int  NOT NULL,
    [sale_unit] nvarchar(50)  NOT NULL,
    [sale_price_per_unit] bigint  NOT NULL,
    [is_active] bit  NULL,
    [expiry_day] datetime  NULL,
    [entry_unit] nvarchar(50)  NULL,
    [entry_price] bigint  NULL,
    [entry_day] datetime  NULL,
    [unit_exchange_ratio] int  NULL,
    [quantity_in_entry_unit] int  NULL
);
GO

-- Creating table 'services_in_bill'
CREATE TABLE [dbo].[services_in_bill] (
    [bills_id] int  NOT NULL,
    [clinic_service_id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'accounts'
ALTER TABLE [dbo].[accounts]
ADD CONSTRAINT [PK_accounts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'bills'
ALTER TABLE [dbo].[bills]
ADD CONSTRAINT [PK_bills]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'clinic_service'
ALTER TABLE [dbo].[clinic_service]
ADD CONSTRAINT [PK_clinic_service]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'patients'
ALTER TABLE [dbo].[patients]
ADD CONSTRAINT [PK_patients]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'permissions'
ALTER TABLE [dbo].[permissions]
ADD CONSTRAINT [PK_permissions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [bill_id], [medicine_id] in table 'prescriptions'
ALTER TABLE [dbo].[prescriptions]
ADD CONSTRAINT [PK_prescriptions]
    PRIMARY KEY CLUSTERED ([bill_id], [medicine_id] ASC);
GO

-- Creating primary key on [id] in table 'staffs'
ALTER TABLE [dbo].[staffs]
ADD CONSTRAINT [PK_staffs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'medicines'
ALTER TABLE [dbo].[medicines]
ADD CONSTRAINT [PK_medicines]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [bills_id], [clinic_service_id] in table 'services_in_bill'
ALTER TABLE [dbo].[services_in_bill]
ADD CONSTRAINT [PK_services_in_bill]
    PRIMARY KEY CLUSTERED ([bills_id], [clinic_service_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [permission_id] in table 'accounts'
ALTER TABLE [dbo].[accounts]
ADD CONSTRAINT [FK_account_permission]
    FOREIGN KEY ([permission_id])
    REFERENCES [dbo].[permissions]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_account_permission'
CREATE INDEX [IX_FK_account_permission]
ON [dbo].[accounts]
    ([permission_id]);
GO

-- Creating foreign key on [staff_id] in table 'accounts'
ALTER TABLE [dbo].[accounts]
ADD CONSTRAINT [FK_staff_account]
    FOREIGN KEY ([staff_id])
    REFERENCES [dbo].[staffs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_staff_account'
CREATE INDEX [IX_FK_staff_account]
ON [dbo].[accounts]
    ([staff_id]);
GO

-- Creating foreign key on [bill_id] in table 'prescriptions'
ALTER TABLE [dbo].[prescriptions]
ADD CONSTRAINT [FK__prescript__bill___4CA06362]
    FOREIGN KEY ([bill_id])
    REFERENCES [dbo].[bills]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [patient_id] in table 'bills'
ALTER TABLE [dbo].[bills]
ADD CONSTRAINT [FK_bill_patient]
    FOREIGN KEY ([patient_id])
    REFERENCES [dbo].[patients]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_bill_patient'
CREATE INDEX [IX_FK_bill_patient]
ON [dbo].[bills]
    ([patient_id]);
GO

-- Creating foreign key on [staff_created] in table 'bills'
ALTER TABLE [dbo].[bills]
ADD CONSTRAINT [FK_bill_staff]
    FOREIGN KEY ([staff_created])
    REFERENCES [dbo].[staffs]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_bill_staff'
CREATE INDEX [IX_FK_bill_staff]
ON [dbo].[bills]
    ([staff_created]);
GO

-- Creating foreign key on [permission_id] in table 'staffs'
ALTER TABLE [dbo].[staffs]
ADD CONSTRAINT [FK_staff_permission]
    FOREIGN KEY ([permission_id])
    REFERENCES [dbo].[permissions]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_staff_permission'
CREATE INDEX [IX_FK_staff_permission]
ON [dbo].[staffs]
    ([permission_id]);
GO

-- Creating foreign key on [bills_id] in table 'services_in_bill'
ALTER TABLE [dbo].[services_in_bill]
ADD CONSTRAINT [FK_services_in_bill_bill]
    FOREIGN KEY ([bills_id])
    REFERENCES [dbo].[bills]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [clinic_service_id] in table 'services_in_bill'
ALTER TABLE [dbo].[services_in_bill]
ADD CONSTRAINT [FK_services_in_bill_clinic_service]
    FOREIGN KEY ([clinic_service_id])
    REFERENCES [dbo].[clinic_service]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_services_in_bill_clinic_service'
CREATE INDEX [IX_FK_services_in_bill_clinic_service]
ON [dbo].[services_in_bill]
    ([clinic_service_id]);
GO

-- Creating foreign key on [medicine_id] in table 'prescriptions'
ALTER TABLE [dbo].[prescriptions]
ADD CONSTRAINT [FK__prescript__medic__4D94879B]
    FOREIGN KEY ([medicine_id])
    REFERENCES [dbo].[medicines]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__prescript__medic__4D94879B'
CREATE INDEX [IX_FK__prescript__medic__4D94879B]
ON [dbo].[prescriptions]
    ([medicine_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------