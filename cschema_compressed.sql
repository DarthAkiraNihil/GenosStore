SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;
DROP DATABASE IF EXISTS genos_store;
CREATE DATABASE genos_store WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
ALTER DATABASE genos_store OWNER TO postgres;
\connect genos_store
SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;
CREATE SCHEMA public;
ALTER SCHEMA public OWNER TO pg_database_owner;
COMMENT ON SCHEMA public IS 'standard public schema';
SET default_tablespace = '';
SET default_table_access_method = heap;
CREATE TABLE public."ActiveDiscounts" (
    "Id" integer NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "EndsAt" timestamp without time zone NOT NULL,
    "Value" double precision NOT NULL
);
ALTER TABLE public."ActiveDiscounts" OWNER TO postgres;
CREATE SEQUENCE public."ActiveDiscounts_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."ActiveDiscounts_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."ActiveDiscounts_Id_seq" OWNED BY public."ActiveDiscounts"."Id";
CREATE TABLE public."Administrators" (
    "Id" integer NOT NULL
);
ALTER TABLE public."Administrators" OWNER TO postgres;
CREATE TABLE public."AudioChipsets" (
    "Id" bigint NOT NULL
);
ALTER TABLE public."AudioChipsets" OWNER TO postgres;
CREATE TABLE public."BankCards" (
    "Id" integer NOT NULL,
    "Number" bigint NOT NULL,
    "BankSystemId" integer NOT NULL,
    "ValidThruMonth" smallint NOT NULL,
    "ValidThruYear" smallint NOT NULL,
    "CVC" smallint NOT NULL,
    "Owner" text NOT NULL,
    "BankSystem_Id" bigint NOT NULL,
    "Customer_Id" integer
);
ALTER TABLE public."BankCards" OWNER TO postgres;
CREATE SEQUENCE public."BankCards_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."BankCards_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."BankCards_Id_seq" OWNED BY public."BankCards"."Id";
CREATE TABLE public."BankSystems" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."BankSystems" OWNER TO postgres;
CREATE SEQUENCE public."BankSystems_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."BankSystems_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."BankSystems_Id_seq" OWNED BY public."BankSystems"."Id";
CREATE TABLE public."CPUCoolers" (
    "Id" integer NOT NULL,
    "FoundationMaterial_Id" bigint NOT NULL,
    "RadiatorMaterial_Id" bigint NOT NULL,
    "MaxFanRPM" bigint NOT NULL,
    "TubesCount" smallint NOT NULL,
    "TubesDiameter" real NOT NULL,
    "FanCount" smallint NOT NULL
);
ALTER TABLE public."CPUCoolers" OWNER TO postgres;
CREATE TABLE public."CPUCores" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Vendor_Id" integer NOT NULL
);
ALTER TABLE public."CPUCores" OWNER TO postgres;
CREATE SEQUENCE public."CPUCores_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."CPUCores_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."CPUCores_Id_seq" OWNED BY public."CPUCores"."Id";
CREATE TABLE public."CPURAMTypes" (
    "CPU_Id" integer NOT NULL,
    "RAMType_Id" bigint NOT NULL
);
ALTER TABLE public."CPURAMTypes" OWNER TO postgres;
CREATE TABLE public."CPUSocket" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."CPUSocket" OWNER TO postgres;
CREATE SEQUENCE public."CPUSocket_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."CPUSocket_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."CPUSocket_Id_seq" OWNED BY public."CPUSocket"."Id";
CREATE TABLE public."CPUs" (
    "Id" integer NOT NULL,
    "CPUCore_Id" integer NOT NULL,
    "CPUSocket_Id" bigint NOT NULL,
    "CoresCount" integer NOT NULL,
    "ThreadsCount" integer NOT NULL,
    "L2CahceSize" real NOT NULL,
    "L3CacheSize" real NOT NULL,
    "TechnicalProcess" real NOT NULL,
    "BaseFrequency" real NOT NULL,
    "SupportedRAMSize" integer NOT NULL,
    "HasIntegratedGraphics" boolean NOT NULL
);
ALTER TABLE public."CPUs" OWNER TO postgres;
CREATE TABLE public."CartItems" (
    "ItemId" integer NOT NULL,
    "Quantity" integer NOT NULL,
    "CartId" integer NOT NULL
);
ALTER TABLE public."CartItems" OWNER TO postgres;
CREATE TABLE public."Carts" (
    "CustomerId" integer NOT NULL,
    "Item_Id" integer
);
ALTER TABLE public."Carts" OWNER TO postgres;
CREATE TABLE public."Certificates80Plus" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."Certificates80Plus" OWNER TO postgres;
CREATE SEQUENCE public."Certificates80Plus_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."Certificates80Plus_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."Certificates80Plus_Id_seq" OWNED BY public."Certificates80Plus"."Id";
CREATE TABLE public."ComputerCaseMotherboardFormFactors" (
    "ComputerCase_Id" integer NOT NULL,
    "MotherboardFormFactor_Id" bigint NOT NULL
);
ALTER TABLE public."ComputerCaseMotherboardFormFactors" OWNER TO postgres;
CREATE TABLE public."ComputerCaseTypesizes" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."ComputerCaseTypesizes" OWNER TO postgres;
CREATE SEQUENCE public."ComputerCaseTypesizes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."ComputerCaseTypesizes_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."ComputerCaseTypesizes_Id_seq" OWNED BY public."ComputerCaseTypesizes"."Id";
CREATE TABLE public."ComputerCases" (
    "Id" integer NOT NULL,
    "ComputerCaseTypesize_Id" bigint NOT NULL,
    "Length" real NOT NULL,
    "Width" real NOT NULL,
    "Height" real NOT NULL,
    "HasARGBLighting" boolean NOT NULL
);
ALTER TABLE public."ComputerCases" OWNER TO postgres;
CREATE TABLE public."CoolerMaterials" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."CoolerMaterials" OWNER TO postgres;
CREATE SEQUENCE public."CoolerMaterials_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."CoolerMaterials_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."CoolerMaterials_Id_seq" OWNED BY public."CoolerMaterials"."Id";
CREATE TABLE public."DPIModes" (
    "Id" integer NOT NULL,
    "DPI" integer NOT NULL
);
ALTER TABLE public."DPIModes" OWNER TO postgres;
CREATE SEQUENCE public."DPIModes_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."DPIModes_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."DPIModes_Id_seq" OWNED BY public."DPIModes"."Id";
CREATE TABLE public."Definitions" (
    "Id" integer NOT NULL,
    "Width" integer NOT NULL,
    "Height" integer NOT NULL
);
ALTER TABLE public."Definitions" OWNER TO postgres;
CREATE SEQUENCE public."Definitions_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."Definitions_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."Definitions_Id_seq" OWNED BY public."Definitions"."Id";
CREATE TABLE public."DiskDrives" (
    "Id" integer NOT NULL,
    "Capacity" bigint NOT NULL,
    "ReadSpeed" bigint NOT NULL,
    "WriteSpeed" bigint NOT NULL
);
ALTER TABLE public."DiskDrives" OWNER TO postgres;
CREATE TABLE public."Displays" (
    "Id" integer NOT NULL,
    "Definition_Id" integer NOT NULL,
    "MatrixType_Id" bigint NOT NULL,
    "Underlight_Id" bigint NOT NULL,
    "VesaSize_Id" bigint NOT NULL,
    "MaxUpdateFrequency" integer NOT NULL,
    "ScreedDiagonal" double precision NOT NULL
);
ALTER TABLE public."Displays" OWNER TO postgres;
CREATE TABLE public."GPUs" (
    "Id" integer NOT NULL,
    "Model" text NOT NULL,
    "Name" text NOT NULL,
    "Vendor_Id" integer NOT NULL
);
ALTER TABLE public."GPUs" OWNER TO postgres;
CREATE SEQUENCE public."GPUs_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."GPUs_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."GPUs_Id_seq" OWNED BY public."GPUs"."Id";
CREATE TABLE public."GraphicsCardVideoPorts" (
    "GraphicsCard_Id" integer NOT NULL,
    "VideoPort_Id" bigint NOT NULL
);
ALTER TABLE public."GraphicsCardVideoPorts" OWNER TO postgres;
CREATE TABLE public."GraphicsCards" (
    "Id" integer NOT NULL,
    "GPU_Id" integer NOT NULL,
    "VideoRAM" integer NOT NULL,
    "MaxDisplaysSupported" smallint NOT NULL,
    "UsedSlots" smallint NOT NULL
);
ALTER TABLE public."GraphicsCards" OWNER TO postgres;
CREATE TABLE public."HDDs" (
    "Id" integer NOT NULL,
    "RPM" integer NOT NULL
);
ALTER TABLE public."HDDs" OWNER TO postgres;
CREATE TABLE public."IndividualEntities" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL,
    "Surname" text NOT NULL,
    "PhoneNumber" text NOT NULL
);
ALTER TABLE public."IndividualEntities" OWNER TO postgres;
CREATE TABLE public."ItemTypes" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."ItemTypes" OWNER TO postgres;
CREATE SEQUENCE public."ItemTypes_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."ItemTypes_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."ItemTypes_Id_seq" OWNED BY public."ItemTypes"."Id";
CREATE TABLE public."Items" (
    "Id" integer NOT NULL,
    "Price" double precision NOT NULL,
    "ImageBase64" text,
    "Description" text NOT NULL,
    "Model" text NOT NULL,
    "Name" text NOT NULL,
    "TDP" double precision,
    "Discriminator" character varying(128),
    "ActiveDiscount_Id" integer,
    "ItemType_Id" integer NOT NULL,
    "Vendor_Id" integer
);
ALTER TABLE public."Items" OWNER TO postgres;
CREATE SEQUENCE public."Items_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."Items_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."Items_Id_seq" OWNED BY public."Items"."Id";
CREATE TABLE public."KeyboardType" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."KeyboardType" OWNER TO postgres;
CREATE SEQUENCE public."KeyboardType_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."KeyboardType_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."KeyboardType_Id_seq" OWNED BY public."KeyboardType"."Id";
CREATE TABLE public."KeyboardTypesizes" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."KeyboardTypesizes" OWNER TO postgres;
CREATE SEQUENCE public."KeyboardTypesizes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."KeyboardTypesizes_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."KeyboardTypesizes_Id_seq" OWNED BY public."KeyboardTypesizes"."Id";
CREATE TABLE public."Keyboards" (
    "Id" integer NOT NULL,
    "KeyboardType_Id" bigint NOT NULL,
    "Typesize_Id" bigint NOT NULL,
    "HasRGBLighting" boolean NOT NULL,
    "IsWireless" boolean NOT NULL
);
ALTER TABLE public."Keyboards" OWNER TO postgres;
CREATE TABLE public."LegalEntities" (
    "Id" integer NOT NULL,
    "INN" bigint NOT NULL,
    "KPP" bigint NOT NULL,
    "PhysicalAddress" text NOT NULL,
    "LegalAddress" text NOT NULL,
    "IsVerified" boolean NOT NULL
);
ALTER TABLE public."LegalEntities" OWNER TO postgres;
CREATE TABLE public."MatrixTypes" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."MatrixTypes" OWNER TO postgres;
CREATE SEQUENCE public."MatrixTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."MatrixTypes_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."MatrixTypes_Id_seq" OWNED BY public."MatrixTypes"."Id";
CREATE TABLE public."MotherboardCPUCores" (
    "Motherboard_Id" integer NOT NULL,
    "CPUCore_Id" integer NOT NULL
);
ALTER TABLE public."MotherboardCPUCores" OWNER TO postgres;
CREATE TABLE public."MotherboardChipsets" (
    "Id" bigint NOT NULL
);
ALTER TABLE public."MotherboardChipsets" OWNER TO postgres;
CREATE TABLE public."MotherboardFormFactors" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."MotherboardFormFactors" OWNER TO postgres;
CREATE SEQUENCE public."MotherboardFormFactors_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."MotherboardFormFactors_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."MotherboardFormFactors_Id_seq" OWNED BY public."MotherboardFormFactors"."Id";
CREATE TABLE public."MotherboardRAMTypes" (
    "Motherboard_Id" integer NOT NULL,
    "RAMType_Id" bigint NOT NULL
);
ALTER TABLE public."MotherboardRAMTypes" OWNER TO postgres;
CREATE TABLE public."MotherboardVideoPorts" (
    "Motherboard_Id" integer NOT NULL,
    "VideoPort_Id" bigint NOT NULL
);
ALTER TABLE public."MotherboardVideoPorts" OWNER TO postgres;
CREATE TABLE public."Motherboards" (
    "Id" integer NOT NULL,
    "AudioChipset_Id" bigint NOT NULL,
    "CPUSocket_Id" bigint NOT NULL,
    "FormFactor_Id" bigint NOT NULL,
    "MotherboardChipset_Id" bigint NOT NULL,
    "NetworkAdapter_Id" bigint NOT NULL,
    "PCIEVersion_Id" bigint NOT NULL,
    "RAMSlots" smallint NOT NULL,
    "RAMChannels" smallint NOT NULL,
    "MaxRAMFrequency" integer NOT NULL,
    "PCIESlotsCount" smallint NOT NULL,
    "PCIEVersionId" integer NOT NULL,
    "HasNVMeSupport" boolean NOT NULL,
    "M2SlotsCount" smallint NOT NULL,
    "SataPortsCount" smallint NOT NULL,
    "USBPortsCount" smallint NOT NULL,
    "RJ45PortsCount" smallint NOT NULL,
    "DigiralAudioPortsCount" smallint NOT NULL,
    "NetworkAdapterSpeed" real NOT NULL
);
ALTER TABLE public."Motherboards" OWNER TO postgres;
CREATE TABLE public."MouseDPIModes" (
    "Mouse_Id" integer NOT NULL,
    "DPIMode_Id" integer NOT NULL
);
ALTER TABLE public."MouseDPIModes" OWNER TO postgres;
CREATE TABLE public."Mouses" (
    "Id" integer NOT NULL,
    "ButtonsCount" smallint NOT NULL,
    "HasProgrammableButtons" boolean NOT NULL,
    "IsWireless" boolean NOT NULL
);
ALTER TABLE public."Mouses" OWNER TO postgres;
CREATE TABLE public."NVMeSSDs" (
    "Id" integer NOT NULL
);
ALTER TABLE public."NVMeSSDs" OWNER TO postgres;
CREATE TABLE public."NetworkAdapters" (
    "Id" bigint NOT NULL
);
ALTER TABLE public."NetworkAdapters" OWNER TO postgres;
CREATE TABLE public."OrderItems" (
    "OrderId" bigint NOT NULL,
    "ItemId" integer NOT NULL,
    "Quantity" integer NOT NULL,
    "BoughtFor" double precision NOT NULL
);
ALTER TABLE public."OrderItems" OWNER TO postgres;
CREATE TABLE public."OrderStatus" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."OrderStatus" OWNER TO postgres;
CREATE SEQUENCE public."OrderStatus_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."OrderStatus_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."OrderStatus_Id_seq" OWNED BY public."OrderStatus"."Id";
CREATE TABLE public."Orders" (
    "Id" bigint NOT NULL,
    "CreatedAt" timestamp without time zone NOT NULL,
    "OrderStatus_Id" bigint NOT NULL,
    "Customer_Id" integer NOT NULL
);
ALTER TABLE public."Orders" OWNER TO postgres;
CREATE SEQUENCE public."Orders_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."Orders_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."Orders_Id_seq" OWNED BY public."Orders"."Id";
CREATE TABLE public."PCIEVersions" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."PCIEVersions" OWNER TO postgres;
CREATE SEQUENCE public."PCIEVersions_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."PCIEVersions_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."PCIEVersions_Id_seq" OWNED BY public."PCIEVersions"."Id";
CREATE TABLE public."PowerSupplies" (
    "Id" integer NOT NULL,
    "Certificate80Plus_Id" bigint NOT NULL,
    "SataPorts" smallint NOT NULL,
    "MolexPorts" smallint NOT NULL,
    "PowerOutput" integer NOT NULL
);
ALTER TABLE public."PowerSupplies" OWNER TO postgres;
CREATE TABLE public."PreparedAssemblies" (
    "Id" integer NOT NULL,
    "ComputerCase_Id" integer NOT NULL,
    "CPU_Id" integer NOT NULL,
    "CPUCooler_Id" integer NOT NULL,
    "Display_Id" integer,
    "GraphicsCard_Id" integer NOT NULL,
    "Keyboard_Id" integer,
    "Motherboard_Id" integer NOT NULL,
    "Mouse_Id" integer,
    "PowerSupply_Id" integer NOT NULL
);
ALTER TABLE public."PreparedAssemblies" OWNER TO postgres;
CREATE TABLE public."PreparedAssemblyDiskDrives" (
    "PreparedAssembly_Id" integer NOT NULL,
    "DiskDrive_Id" integer NOT NULL
);
ALTER TABLE public."PreparedAssemblyDiskDrives" OWNER TO postgres;
CREATE TABLE public."PreparedAssemblyRAMs" (
    "PreparedAssembly_Id" integer NOT NULL,
    "RAM_Id" integer NOT NULL
);
ALTER TABLE public."PreparedAssemblyRAMs" OWNER TO postgres;
CREATE TABLE public."RAMTypes" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."RAMTypes" OWNER TO postgres;
CREATE SEQUENCE public."RAMTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."RAMTypes_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."RAMTypes_Id_seq" OWNED BY public."RAMTypes"."Id";
CREATE TABLE public."RAMs" (
    "Id" integer NOT NULL,
    "RAMType_Id" bigint NOT NULL,
    "TotalSize" integer NOT NULL,
    "ModuleSize" integer NOT NULL,
    "ModulesCount" smallint NOT NULL,
    "Frequency" integer NOT NULL,
    "CL" smallint NOT NULL,
    "tRCD" smallint NOT NULL,
    "tRP" smallint NOT NULL,
    "tRAS" smallint NOT NULL
);
ALTER TABLE public."RAMs" OWNER TO postgres;
CREATE TABLE public."SSDControllers" (
    "Id" bigint NOT NULL
);
ALTER TABLE public."SSDControllers" OWNER TO postgres;
CREATE TABLE public."SSDs" (
    "Id" integer NOT NULL,
    "SSDController_Id" bigint NOT NULL,
    "TBW" integer NOT NULL,
    "DWPD" real NOT NULL,
    "BitsForCell" smallint NOT NULL
);
ALTER TABLE public."SSDs" OWNER TO postgres;
CREATE TABLE public."SataSSDs" (
    "Id" integer NOT NULL
);
ALTER TABLE public."SataSSDs" OWNER TO postgres;
CREATE TABLE public."SimpleComputerComponentTypes" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."SimpleComputerComponentTypes" OWNER TO postgres;
CREATE SEQUENCE public."SimpleComputerComponentTypes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."SimpleComputerComponentTypes_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."SimpleComputerComponentTypes_Id_seq" OWNED BY public."SimpleComputerComponentTypes"."Id";
CREATE TABLE public."SimpleComputerComponents" (
    "Id" bigint NOT NULL,
    "Model" text NOT NULL,
    "Name" text NOT NULL,
    "Type_Id" bigint NOT NULL
);
ALTER TABLE public."SimpleComputerComponents" OWNER TO postgres;
CREATE SEQUENCE public."SimpleComputerComponents_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."SimpleComputerComponents_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."SimpleComputerComponents_Id_seq" OWNED BY public."SimpleComputerComponents"."Id";
CREATE TABLE public."Underlights" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."Underlights" OWNER TO postgres;
CREATE SEQUENCE public."Underlights_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."Underlights_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."Underlights_Id_seq" OWNED BY public."Underlights"."Id";
CREATE TABLE public."Users" (
    "Id" integer NOT NULL,
    "Email" text NOT NULL,
    "PasswordHash" text NOT NULL,
    "Salt" text NOT NULL
);
ALTER TABLE public."Users" OWNER TO postgres;
CREATE SEQUENCE public."Users_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."Users_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."Users_Id_seq" OWNED BY public."Users"."Id";
CREATE TABLE public."Vendors" (
    "Id" integer NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."Vendors" OWNER TO postgres;
CREATE SEQUENCE public."Vendors_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."Vendors_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."Vendors_Id_seq" OWNED BY public."Vendors"."Id";
CREATE TABLE public."VesaSizes" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."VesaSizes" OWNER TO postgres;
CREATE SEQUENCE public."VesaSizes_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."VesaSizes_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."VesaSizes_Id_seq" OWNED BY public."VesaSizes"."Id";
CREATE TABLE public."VideoPorts" (
    "Id" bigint NOT NULL,
    "Name" text NOT NULL
);
ALTER TABLE public."VideoPorts" OWNER TO postgres;
CREATE SEQUENCE public."VideoPorts_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
ALTER SEQUENCE public."VideoPorts_Id_seq" OWNER TO postgres;
ALTER SEQUENCE public."VideoPorts_Id_seq" OWNED BY public."VideoPorts"."Id";
CREATE TABLE public."__MigrationHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ContextKey" character varying(300) NOT NULL,
    "Model" bytea NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
ALTER TABLE public."__MigrationHistory" OWNER TO postgres;
ALTER TABLE ONLY public."ActiveDiscounts" ALTER COLUMN "Id" SET DEFAULT nextval('public."ActiveDiscounts_Id_seq"'::regclass);
ALTER TABLE ONLY public."BankCards" ALTER COLUMN "Id" SET DEFAULT nextval('public."BankCards_Id_seq"'::regclass);
ALTER TABLE ONLY public."BankSystems" ALTER COLUMN "Id" SET DEFAULT nextval('public."BankSystems_Id_seq"'::regclass);
ALTER TABLE ONLY public."CPUCores" ALTER COLUMN "Id" SET DEFAULT nextval('public."CPUCores_Id_seq"'::regclass);
ALTER TABLE ONLY public."CPUSocket" ALTER COLUMN "Id" SET DEFAULT nextval('public."CPUSocket_Id_seq"'::regclass);
ALTER TABLE ONLY public."Certificates80Plus" ALTER COLUMN "Id" SET DEFAULT nextval('public."Certificates80Plus_Id_seq"'::regclass);
ALTER TABLE ONLY public."ComputerCaseTypesizes" ALTER COLUMN "Id" SET DEFAULT nextval('public."ComputerCaseTypesizes_Id_seq"'::regclass);
ALTER TABLE ONLY public."CoolerMaterials" ALTER COLUMN "Id" SET DEFAULT nextval('public."CoolerMaterials_Id_seq"'::regclass);
ALTER TABLE ONLY public."DPIModes" ALTER COLUMN "Id" SET DEFAULT nextval('public."DPIModes_Id_seq"'::regclass);
ALTER TABLE ONLY public."Definitions" ALTER COLUMN "Id" SET DEFAULT nextval('public."Definitions_Id_seq"'::regclass);
ALTER TABLE ONLY public."GPUs" ALTER COLUMN "Id" SET DEFAULT nextval('public."GPUs_Id_seq"'::regclass);
ALTER TABLE ONLY public."ItemTypes" ALTER COLUMN "Id" SET DEFAULT nextval('public."ItemTypes_Id_seq"'::regclass);
ALTER TABLE ONLY public."Items" ALTER COLUMN "Id" SET DEFAULT nextval('public."Items_Id_seq"'::regclass);
ALTER TABLE ONLY public."KeyboardType" ALTER COLUMN "Id" SET DEFAULT nextval('public."KeyboardType_Id_seq"'::regclass);
ALTER TABLE ONLY public."KeyboardTypesizes" ALTER COLUMN "Id" SET DEFAULT nextval('public."KeyboardTypesizes_Id_seq"'::regclass);
ALTER TABLE ONLY public."MatrixTypes" ALTER COLUMN "Id" SET DEFAULT nextval('public."MatrixTypes_Id_seq"'::regclass);
ALTER TABLE ONLY public."MotherboardFormFactors" ALTER COLUMN "Id" SET DEFAULT nextval('public."MotherboardFormFactors_Id_seq"'::regclass);
ALTER TABLE ONLY public."OrderStatus" ALTER COLUMN "Id" SET DEFAULT nextval('public."OrderStatus_Id_seq"'::regclass);
ALTER TABLE ONLY public."Orders" ALTER COLUMN "Id" SET DEFAULT nextval('public."Orders_Id_seq"'::regclass);
ALTER TABLE ONLY public."PCIEVersions" ALTER COLUMN "Id" SET DEFAULT nextval('public."PCIEVersions_Id_seq"'::regclass);
ALTER TABLE ONLY public."RAMTypes" ALTER COLUMN "Id" SET DEFAULT nextval('public."RAMTypes_Id_seq"'::regclass);
ALTER TABLE ONLY public."SimpleComputerComponentTypes" ALTER COLUMN "Id" SET DEFAULT nextval('public."SimpleComputerComponentTypes_Id_seq"'::regclass);
ALTER TABLE ONLY public."SimpleComputerComponents" ALTER COLUMN "Id" SET DEFAULT nextval('public."SimpleComputerComponents_Id_seq"'::regclass);
ALTER TABLE ONLY public."Underlights" ALTER COLUMN "Id" SET DEFAULT nextval('public."Underlights_Id_seq"'::regclass);
ALTER TABLE ONLY public."Users" ALTER COLUMN "Id" SET DEFAULT nextval('public."Users_Id_seq"'::regclass);
ALTER TABLE ONLY public."Vendors" ALTER COLUMN "Id" SET DEFAULT nextval('public."Vendors_Id_seq"'::regclass);
ALTER TABLE ONLY public."VesaSizes" ALTER COLUMN "Id" SET DEFAULT nextval('public."VesaSizes_Id_seq"'::regclass);
ALTER TABLE ONLY public."VideoPorts" ALTER COLUMN "Id" SET DEFAULT nextval('public."VideoPorts_Id_seq"'::regclass);
ALTER TABLE ONLY public."ActiveDiscounts"
    ADD CONSTRAINT "PK_public.ActiveDiscounts" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."Administrators"
    ADD CONSTRAINT "PK_public.Administrators" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."AudioChipsets"
    ADD CONSTRAINT "PK_public.AudioChipsets" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."BankCards"
    ADD CONSTRAINT "PK_public.BankCards" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."BankSystems"
    ADD CONSTRAINT "PK_public.BankSystems" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."CPUCoolers"
    ADD CONSTRAINT "PK_public.CPUCoolers" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."CPUCores"
    ADD CONSTRAINT "PK_public.CPUCores" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."CPURAMTypes"
    ADD CONSTRAINT "PK_public.CPURAMTypes" PRIMARY KEY ("CPU_Id", "RAMType_Id");
ALTER TABLE ONLY public."CPUSocket"
    ADD CONSTRAINT "PK_public.CPUSocket" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."CPUs"
    ADD CONSTRAINT "PK_public.CPUs" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."Carts"
    ADD CONSTRAINT "PK_public.Carts" PRIMARY KEY ("CustomerId");
ALTER TABLE ONLY public."Certificates80Plus"
    ADD CONSTRAINT "PK_public.Certificates80Plus" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."ComputerCaseMotherboardFormFactors"
    ADD CONSTRAINT "PK_public.ComputerCaseMotherboardFormFactors" PRIMARY KEY ("ComputerCase_Id", "MotherboardFormFactor_Id");
ALTER TABLE ONLY public."ComputerCaseTypesizes"
    ADD CONSTRAINT "PK_public.ComputerCaseTypesizes" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."ComputerCases"
    ADD CONSTRAINT "PK_public.ComputerCases" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."CoolerMaterials"
    ADD CONSTRAINT "PK_public.CoolerMaterials" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."DPIModes"
    ADD CONSTRAINT "PK_public.DPIModes" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."Definitions"
    ADD CONSTRAINT "PK_public.Definitions" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."DiskDrives"
    ADD CONSTRAINT "PK_public.DiskDrives" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."Displays"
    ADD CONSTRAINT "PK_public.Displays" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."GPUs"
    ADD CONSTRAINT "PK_public.GPUs" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."GraphicsCardVideoPorts"
    ADD CONSTRAINT "PK_public.GraphicsCardVideoPorts" PRIMARY KEY ("GraphicsCard_Id", "VideoPort_Id");
ALTER TABLE ONLY public."GraphicsCards"
    ADD CONSTRAINT "PK_public.GraphicsCards" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."HDDs"
    ADD CONSTRAINT "PK_public.HDDs" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."IndividualEntities"
    ADD CONSTRAINT "PK_public.IndividualEntities" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."ItemTypes"
    ADD CONSTRAINT "PK_public.ItemTypes" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."Items"
    ADD CONSTRAINT "PK_public.Items" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."KeyboardType"
    ADD CONSTRAINT "PK_public.KeyboardType" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."KeyboardTypesizes"
    ADD CONSTRAINT "PK_public.KeyboardTypesizes" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."Keyboards"
    ADD CONSTRAINT "PK_public.Keyboards" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."LegalEntities"
    ADD CONSTRAINT "PK_public.LegalEntities" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."MatrixTypes"
    ADD CONSTRAINT "PK_public.MatrixTypes" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."MotherboardCPUCores"
    ADD CONSTRAINT "PK_public.MotherboardCPUCores" PRIMARY KEY ("Motherboard_Id", "CPUCore_Id");
ALTER TABLE ONLY public."MotherboardChipsets"
    ADD CONSTRAINT "PK_public.MotherboardChipsets" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."MotherboardFormFactors"
    ADD CONSTRAINT "PK_public.MotherboardFormFactors" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."MotherboardRAMTypes"
    ADD CONSTRAINT "PK_public.MotherboardRAMTypes" PRIMARY KEY ("Motherboard_Id", "RAMType_Id");
ALTER TABLE ONLY public."MotherboardVideoPorts"
    ADD CONSTRAINT "PK_public.MotherboardVideoPorts" PRIMARY KEY ("Motherboard_Id", "VideoPort_Id");
ALTER TABLE ONLY public."Motherboards"
    ADD CONSTRAINT "PK_public.Motherboards" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."MouseDPIModes"
    ADD CONSTRAINT "PK_public.MouseDPIModes" PRIMARY KEY ("Mouse_Id", "DPIMode_Id");
ALTER TABLE ONLY public."Mouses"
    ADD CONSTRAINT "PK_public.Mouses" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."NVMeSSDs"
    ADD CONSTRAINT "PK_public.NVMeSSDs" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."NetworkAdapters"
    ADD CONSTRAINT "PK_public.NetworkAdapters" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."OrderItems"
    ADD CONSTRAINT "PK_public.OrderItems" PRIMARY KEY ("OrderId", "ItemId");
ALTER TABLE ONLY public."OrderStatus"
    ADD CONSTRAINT "PK_public.OrderStatus" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "PK_public.Orders" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."PCIEVersions"
    ADD CONSTRAINT "PK_public.PCIEVersions" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."PowerSupplies"
    ADD CONSTRAINT "PK_public.PowerSupplies" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."PreparedAssemblies"
    ADD CONSTRAINT "PK_public.PreparedAssemblies" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."PreparedAssemblyDiskDrives"
    ADD CONSTRAINT "PK_public.PreparedAssemblyDiskDrives" PRIMARY KEY ("PreparedAssembly_Id", "DiskDrive_Id");
ALTER TABLE ONLY public."PreparedAssemblyRAMs"
    ADD CONSTRAINT "PK_public.PreparedAssemblyRAMs" PRIMARY KEY ("PreparedAssembly_Id", "RAM_Id");
ALTER TABLE ONLY public."RAMTypes"
    ADD CONSTRAINT "PK_public.RAMTypes" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."RAMs"
    ADD CONSTRAINT "PK_public.RAMs" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."SSDControllers"
    ADD CONSTRAINT "PK_public.SSDControllers" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."SSDs"
    ADD CONSTRAINT "PK_public.SSDs" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."SataSSDs"
    ADD CONSTRAINT "PK_public.SataSSDs" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."SimpleComputerComponentTypes"
    ADD CONSTRAINT "PK_public.SimpleComputerComponentTypes" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."SimpleComputerComponents"
    ADD CONSTRAINT "PK_public.SimpleComputerComponents" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."Underlights"
    ADD CONSTRAINT "PK_public.Underlights" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_public.Users" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."Vendors"
    ADD CONSTRAINT "PK_public.Vendors" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."VesaSizes"
    ADD CONSTRAINT "PK_public.VesaSizes" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."VideoPorts"
    ADD CONSTRAINT "PK_public.VideoPorts" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."__MigrationHistory"
    ADD CONSTRAINT "PK_public.__MigrationHistory" PRIMARY KEY ("MigrationId", "ContextKey");
CREATE INDEX "Administrators_IX_Id" ON public."Administrators" USING btree ("Id");
CREATE INDEX "AudioChipsets_IX_Id" ON public."AudioChipsets" USING btree ("Id");
CREATE INDEX "BankCards_IX_BankSystem_Id" ON public."BankCards" USING btree ("BankSystem_Id");
CREATE INDEX "BankCards_IX_Customer_Id" ON public."BankCards" USING btree ("Customer_Id");
CREATE INDEX "CPUCoolers_IX_FoundationMaterial_Id" ON public."CPUCoolers" USING btree ("FoundationMaterial_Id");
CREATE INDEX "CPUCoolers_IX_Id" ON public."CPUCoolers" USING btree ("Id");
CREATE INDEX "CPUCoolers_IX_RadiatorMaterial_Id" ON public."CPUCoolers" USING btree ("RadiatorMaterial_Id");
CREATE INDEX "CPUCores_IX_Vendor_Id" ON public."CPUCores" USING btree ("Vendor_Id");
CREATE INDEX "CPURAMTypes_IX_CPU_Id" ON public."CPURAMTypes" USING btree ("CPU_Id");
CREATE INDEX "CPURAMTypes_IX_RAMType_Id" ON public."CPURAMTypes" USING btree ("RAMType_Id");
CREATE INDEX "CPUs_IX_CPUCore_Id" ON public."CPUs" USING btree ("CPUCore_Id");
CREATE INDEX "CPUs_IX_CPUSocket_Id" ON public."CPUs" USING btree ("CPUSocket_Id");
CREATE INDEX "CPUs_IX_Id" ON public."CPUs" USING btree ("Id");
CREATE INDEX "CartItems_IX_Cart_CustomerId" ON public."CartItems" USING btree ("CartId");
CREATE INDEX "CartItems_IX_ItemId" ON public."CartItems" USING btree ("ItemId");
CREATE INDEX "Carts_IX_CustomerId" ON public."Carts" USING btree ("CustomerId");
CREATE INDEX "Carts_IX_Item_Id" ON public."Carts" USING btree ("Item_Id");
CREATE INDEX "ComputerCaseMotherboardFormFactors_IX_ComputerCase_Id" ON public."ComputerCaseMotherboardFormFactors" USING btree ("ComputerCase_Id");
CREATE INDEX "ComputerCaseMotherboardFormFactors_IX_MotherboardFormFactor_Id" ON public."ComputerCaseMotherboardFormFactors" USING btree ("MotherboardFormFactor_Id");
CREATE INDEX "ComputerCases_IX_ComputerCaseTypesize_Id" ON public."ComputerCases" USING btree ("ComputerCaseTypesize_Id");
CREATE INDEX "ComputerCases_IX_Id" ON public."ComputerCases" USING btree ("Id");
CREATE INDEX "DiskDrives_IX_Id" ON public."DiskDrives" USING btree ("Id");
CREATE INDEX "Displays_IX_Definition_Id" ON public."Displays" USING btree ("Definition_Id");
CREATE INDEX "Displays_IX_Id" ON public."Displays" USING btree ("Id");
CREATE INDEX "Displays_IX_MatrixType_Id" ON public."Displays" USING btree ("MatrixType_Id");
CREATE INDEX "Displays_IX_Underlight_Id" ON public."Displays" USING btree ("Underlight_Id");
CREATE INDEX "Displays_IX_VesaSize_Id" ON public."Displays" USING btree ("VesaSize_Id");
CREATE INDEX "GPUs_IX_Vendor_Id" ON public."GPUs" USING btree ("Vendor_Id");
CREATE INDEX "GraphicsCardVideoPorts_IX_GraphicsCard_Id" ON public."GraphicsCardVideoPorts" USING btree ("GraphicsCard_Id");
CREATE INDEX "GraphicsCardVideoPorts_IX_VideoPort_Id" ON public."GraphicsCardVideoPorts" USING btree ("VideoPort_Id");
CREATE INDEX "GraphicsCards_IX_GPU_Id" ON public."GraphicsCards" USING btree ("GPU_Id");
CREATE INDEX "GraphicsCards_IX_Id" ON public."GraphicsCards" USING btree ("Id");
CREATE INDEX "HDDs_IX_Id" ON public."HDDs" USING btree ("Id");
CREATE INDEX "IndividualEntities_IX_Id" ON public."IndividualEntities" USING btree ("Id");
CREATE INDEX "Items_IX_ActiveDiscount_Id" ON public."Items" USING btree ("ActiveDiscount_Id");
CREATE INDEX "Items_IX_ItemType_Id" ON public."Items" USING btree ("ItemType_Id");
CREATE INDEX "Items_IX_Vendor_Id" ON public."Items" USING btree ("Vendor_Id");
CREATE INDEX "Keyboards_IX_Id" ON public."Keyboards" USING btree ("Id");
CREATE INDEX "Keyboards_IX_KeyboardType_Id" ON public."Keyboards" USING btree ("KeyboardType_Id");
CREATE INDEX "Keyboards_IX_Typesize_Id" ON public."Keyboards" USING btree ("Typesize_Id");
CREATE INDEX "LegalEntities_IX_Id" ON public."LegalEntities" USING btree ("Id");
CREATE INDEX "MotherboardCPUCores_IX_CPUCore_Id" ON public."MotherboardCPUCores" USING btree ("CPUCore_Id");
CREATE INDEX "MotherboardCPUCores_IX_Motherboard_Id" ON public."MotherboardCPUCores" USING btree ("Motherboard_Id");
CREATE INDEX "MotherboardChipsets_IX_Id" ON public."MotherboardChipsets" USING btree ("Id");
CREATE INDEX "MotherboardRAMTypes_IX_Motherboard_Id" ON public."MotherboardRAMTypes" USING btree ("Motherboard_Id");
CREATE INDEX "MotherboardRAMTypes_IX_RAMType_Id" ON public."MotherboardRAMTypes" USING btree ("RAMType_Id");
CREATE INDEX "MotherboardVideoPorts_IX_Motherboard_Id" ON public."MotherboardVideoPorts" USING btree ("Motherboard_Id");
CREATE INDEX "MotherboardVideoPorts_IX_VideoPort_Id" ON public."MotherboardVideoPorts" USING btree ("VideoPort_Id");
CREATE INDEX "Motherboards_IX_AudioChipset_Id" ON public."Motherboards" USING btree ("AudioChipset_Id");
CREATE INDEX "Motherboards_IX_CPUSocket_Id" ON public."Motherboards" USING btree ("CPUSocket_Id");
CREATE INDEX "Motherboards_IX_FormFactor_Id" ON public."Motherboards" USING btree ("FormFactor_Id");
CREATE INDEX "Motherboards_IX_Id" ON public."Motherboards" USING btree ("Id");
CREATE INDEX "Motherboards_IX_MotherboardChipset_Id" ON public."Motherboards" USING btree ("MotherboardChipset_Id");
CREATE INDEX "Motherboards_IX_NetworkAdapter_Id" ON public."Motherboards" USING btree ("NetworkAdapter_Id");
CREATE INDEX "Motherboards_IX_PCIEVersion_Id" ON public."Motherboards" USING btree ("PCIEVersion_Id");
CREATE INDEX "MouseDPIModes_IX_DPIMode_Id" ON public."MouseDPIModes" USING btree ("DPIMode_Id");
CREATE INDEX "MouseDPIModes_IX_Mouse_Id" ON public."MouseDPIModes" USING btree ("Mouse_Id");
CREATE INDEX "Mouses_IX_Id" ON public."Mouses" USING btree ("Id");
CREATE INDEX "NVMeSSDs_IX_Id" ON public."NVMeSSDs" USING btree ("Id");
CREATE INDEX "NetworkAdapters_IX_Id" ON public."NetworkAdapters" USING btree ("Id");
CREATE INDEX "OrderItems_IX_ItemId" ON public."OrderItems" USING btree ("ItemId");
CREATE INDEX "OrderItems_IX_OrderId" ON public."OrderItems" USING btree ("OrderId");
CREATE INDEX "Orders_IX_Customer_Id" ON public."Orders" USING btree ("Customer_Id");
CREATE INDEX "Orders_IX_OrderStatus_Id" ON public."Orders" USING btree ("OrderStatus_Id");
CREATE INDEX "PowerSupplies_IX_Certificate80Plus_Id" ON public."PowerSupplies" USING btree ("Certificate80Plus_Id");
CREATE INDEX "PowerSupplies_IX_Id" ON public."PowerSupplies" USING btree ("Id");
CREATE INDEX "PreparedAssemblies_IX_CPUCooler_Id" ON public."PreparedAssemblies" USING btree ("CPUCooler_Id");
CREATE INDEX "PreparedAssemblies_IX_CPU_Id" ON public."PreparedAssemblies" USING btree ("CPU_Id");
CREATE INDEX "PreparedAssemblies_IX_ComputerCase_Id" ON public."PreparedAssemblies" USING btree ("ComputerCase_Id");
CREATE INDEX "PreparedAssemblies_IX_Display_Id" ON public."PreparedAssemblies" USING btree ("Display_Id");
CREATE INDEX "PreparedAssemblies_IX_GraphicsCard_Id" ON public."PreparedAssemblies" USING btree ("GraphicsCard_Id");
CREATE INDEX "PreparedAssemblies_IX_Id" ON public."PreparedAssemblies" USING btree ("Id");
CREATE INDEX "PreparedAssemblies_IX_Keyboard_Id" ON public."PreparedAssemblies" USING btree ("Keyboard_Id");
CREATE INDEX "PreparedAssemblies_IX_Motherboard_Id" ON public."PreparedAssemblies" USING btree ("Motherboard_Id");
CREATE INDEX "PreparedAssemblies_IX_Mouse_Id" ON public."PreparedAssemblies" USING btree ("Mouse_Id");
CREATE INDEX "PreparedAssemblies_IX_PowerSupply_Id" ON public."PreparedAssemblies" USING btree ("PowerSupply_Id");
CREATE INDEX "PreparedAssemblyDiskDrives_IX_DiskDrive_Id" ON public."PreparedAssemblyDiskDrives" USING btree ("DiskDrive_Id");
CREATE INDEX "PreparedAssemblyDiskDrives_IX_PreparedAssembly_Id" ON public."PreparedAssemblyDiskDrives" USING btree ("PreparedAssembly_Id");
CREATE INDEX "PreparedAssemblyRAMs_IX_PreparedAssembly_Id" ON public."PreparedAssemblyRAMs" USING btree ("PreparedAssembly_Id");
CREATE INDEX "PreparedAssemblyRAMs_IX_RAM_Id" ON public."PreparedAssemblyRAMs" USING btree ("RAM_Id");
CREATE INDEX "RAMs_IX_Id" ON public."RAMs" USING btree ("Id");
CREATE INDEX "RAMs_IX_RAMType_Id" ON public."RAMs" USING btree ("RAMType_Id");
CREATE INDEX "SSDControllers_IX_Id" ON public."SSDControllers" USING btree ("Id");
CREATE INDEX "SSDs_IX_Id" ON public."SSDs" USING btree ("Id");
CREATE INDEX "SSDs_IX_SSDController_Id" ON public."SSDs" USING btree ("SSDController_Id");
CREATE INDEX "SataSSDs_IX_Id" ON public."SataSSDs" USING btree ("Id");
CREATE INDEX "SimpleComputerComponents_IX_Type_Id" ON public."SimpleComputerComponents" USING btree ("Type_Id");
ALTER TABLE ONLY public."Administrators"
    ADD CONSTRAINT "FK_public.Administrators_public.Users_Id" FOREIGN KEY ("Id") REFERENCES public."Users"("Id");
ALTER TABLE ONLY public."AudioChipsets"
    ADD CONSTRAINT "FK_public.AudioChipsets_public.SimpleComputerComponents_Id" FOREIGN KEY ("Id") REFERENCES public."SimpleComputerComponents"("Id");
ALTER TABLE ONLY public."BankCards"
    ADD CONSTRAINT "FK_public.BankCards_public.BankSystems_BankSystem_Id" FOREIGN KEY ("BankSystem_Id") REFERENCES public."BankSystems"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."BankCards"
    ADD CONSTRAINT "FK_public.BankCards_public.Users_Customer_Id" FOREIGN KEY ("Customer_Id") REFERENCES public."Users"("Id");
ALTER TABLE ONLY public."CPUCoolers"
    ADD CONSTRAINT "FK_public.CPUCoolers_public.CoolerMaterials_FoundationMaterial_" FOREIGN KEY ("FoundationMaterial_Id") REFERENCES public."CoolerMaterials"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."CPUCoolers"
    ADD CONSTRAINT "FK_public.CPUCoolers_public.CoolerMaterials_RadiatorMaterial_Id" FOREIGN KEY ("RadiatorMaterial_Id") REFERENCES public."CoolerMaterials"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."CPUCoolers"
    ADD CONSTRAINT "FK_public.CPUCoolers_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."CPUCores"
    ADD CONSTRAINT "FK_public.CPUCores_public.Vendors_Vendor_Id" FOREIGN KEY ("Vendor_Id") REFERENCES public."Vendors"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."CPURAMTypes"
    ADD CONSTRAINT "FK_public.CPURAMTypes_public.CPUs_CPU_Id" FOREIGN KEY ("CPU_Id") REFERENCES public."CPUs"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."CPURAMTypes"
    ADD CONSTRAINT "FK_public.CPURAMTypes_public.RAMTypes_RAMType_Id" FOREIGN KEY ("RAMType_Id") REFERENCES public."RAMTypes"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."CPUs"
    ADD CONSTRAINT "FK_public.CPUs_public.CPUCores_CPUCore_Id" FOREIGN KEY ("CPUCore_Id") REFERENCES public."CPUCores"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."CPUs"
    ADD CONSTRAINT "FK_public.CPUs_public.CPUSocket_CPUSocket_Id" FOREIGN KEY ("CPUSocket_Id") REFERENCES public."CPUSocket"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."CPUs"
    ADD CONSTRAINT "FK_public.CPUs_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."CartItems"
    ADD CONSTRAINT "FK_public.CartItems_public.Carts_Cart_CustomerId" FOREIGN KEY ("CartId") REFERENCES public."Carts"("CustomerId") ON DELETE CASCADE;
ALTER TABLE ONLY public."CartItems"
    ADD CONSTRAINT "FK_public.CartItems_public.Items_ItemId" FOREIGN KEY ("ItemId") REFERENCES public."Items"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Carts"
    ADD CONSTRAINT "FK_public.Carts_public.Items_Item_Id" FOREIGN KEY ("Item_Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."Carts"
    ADD CONSTRAINT "FK_public.Carts_public.Users_CustomerId" FOREIGN KEY ("CustomerId") REFERENCES public."Users"("Id");
ALTER TABLE ONLY public."ComputerCaseMotherboardFormFactors"
    ADD CONSTRAINT "FK_public.ComputerCaseMotherboardFormFactors_public.ComputerCas" FOREIGN KEY ("ComputerCase_Id") REFERENCES public."ComputerCases"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."ComputerCaseMotherboardFormFactors"
    ADD CONSTRAINT "FK_public.ComputerCaseMotherboardFormFactors_public.Motherboard" FOREIGN KEY ("MotherboardFormFactor_Id") REFERENCES public."MotherboardFormFactors"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."ComputerCases"
    ADD CONSTRAINT "FK_public.ComputerCases_public.ComputerCaseTypesizes_ComputerCa" FOREIGN KEY ("ComputerCaseTypesize_Id") REFERENCES public."ComputerCaseTypesizes"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."ComputerCases"
    ADD CONSTRAINT "FK_public.ComputerCases_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."DiskDrives"
    ADD CONSTRAINT "FK_public.DiskDrives_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."Displays"
    ADD CONSTRAINT "FK_public.Displays_public.Definitions_Definition_Id" FOREIGN KEY ("Definition_Id") REFERENCES public."Definitions"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Displays"
    ADD CONSTRAINT "FK_public.Displays_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."Displays"
    ADD CONSTRAINT "FK_public.Displays_public.MatrixTypes_MatrixType_Id" FOREIGN KEY ("MatrixType_Id") REFERENCES public."MatrixTypes"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Displays"
    ADD CONSTRAINT "FK_public.Displays_public.Underlights_Underlight_Id" FOREIGN KEY ("Underlight_Id") REFERENCES public."Underlights"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Displays"
    ADD CONSTRAINT "FK_public.Displays_public.VesaSizes_VesaSize_Id" FOREIGN KEY ("VesaSize_Id") REFERENCES public."VesaSizes"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."GPUs"
    ADD CONSTRAINT "FK_public.GPUs_public.Vendors_Vendor_Id" FOREIGN KEY ("Vendor_Id") REFERENCES public."Vendors"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."GraphicsCardVideoPorts"
    ADD CONSTRAINT "FK_public.GraphicsCardVideoPorts_public.GraphicsCards_GraphicsC" FOREIGN KEY ("GraphicsCard_Id") REFERENCES public."GraphicsCards"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."GraphicsCardVideoPorts"
    ADD CONSTRAINT "FK_public.GraphicsCardVideoPorts_public.VideoPorts_VideoPort_Id" FOREIGN KEY ("VideoPort_Id") REFERENCES public."VideoPorts"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."GraphicsCards"
    ADD CONSTRAINT "FK_public.GraphicsCards_public.GPUs_GPU_Id" FOREIGN KEY ("GPU_Id") REFERENCES public."GPUs"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."GraphicsCards"
    ADD CONSTRAINT "FK_public.GraphicsCards_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."HDDs"
    ADD CONSTRAINT "FK_public.HDDs_public.DiskDrives_Id" FOREIGN KEY ("Id") REFERENCES public."DiskDrives"("Id");
ALTER TABLE ONLY public."IndividualEntities"
    ADD CONSTRAINT "FK_public.IndividualEntities_public.Users_Id" FOREIGN KEY ("Id") REFERENCES public."Users"("Id");
ALTER TABLE ONLY public."Items"
    ADD CONSTRAINT "FK_public.Items_public.ActiveDiscounts_ActiveDiscount_Id" FOREIGN KEY ("ActiveDiscount_Id") REFERENCES public."ActiveDiscounts"("Id");
ALTER TABLE ONLY public."Items"
    ADD CONSTRAINT "FK_public.Items_public.ItemTypes_ItemType_Id" FOREIGN KEY ("ItemType_Id") REFERENCES public."ItemTypes"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Items"
    ADD CONSTRAINT "FK_public.Items_public.Vendors_Vendor_Id" FOREIGN KEY ("Vendor_Id") REFERENCES public."Vendors"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Keyboards"
    ADD CONSTRAINT "FK_public.Keyboards_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."Keyboards"
    ADD CONSTRAINT "FK_public.Keyboards_public.KeyboardType_KeyboardType_Id" FOREIGN KEY ("KeyboardType_Id") REFERENCES public."KeyboardType"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Keyboards"
    ADD CONSTRAINT "FK_public.Keyboards_public.KeyboardTypesizes_Typesize_Id" FOREIGN KEY ("Typesize_Id") REFERENCES public."KeyboardTypesizes"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."LegalEntities"
    ADD CONSTRAINT "FK_public.LegalEntities_public.Users_Id" FOREIGN KEY ("Id") REFERENCES public."Users"("Id");
ALTER TABLE ONLY public."MotherboardCPUCores"
    ADD CONSTRAINT "FK_public.MotherboardCPUCores_public.CPUCores_CPUCore_Id" FOREIGN KEY ("CPUCore_Id") REFERENCES public."CPUCores"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."MotherboardCPUCores"
    ADD CONSTRAINT "FK_public.MotherboardCPUCores_public.Motherboards_Motherboard_I" FOREIGN KEY ("Motherboard_Id") REFERENCES public."Motherboards"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."MotherboardChipsets"
    ADD CONSTRAINT "FK_public.MotherboardChipsets_public.SimpleComputerComponents_I" FOREIGN KEY ("Id") REFERENCES public."SimpleComputerComponents"("Id");
ALTER TABLE ONLY public."MotherboardRAMTypes"
    ADD CONSTRAINT "FK_public.MotherboardRAMTypes_public.Motherboards_Motherboard_I" FOREIGN KEY ("Motherboard_Id") REFERENCES public."Motherboards"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."MotherboardRAMTypes"
    ADD CONSTRAINT "FK_public.MotherboardRAMTypes_public.RAMTypes_RAMType_Id" FOREIGN KEY ("RAMType_Id") REFERENCES public."RAMTypes"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."MotherboardVideoPorts"
    ADD CONSTRAINT "FK_public.MotherboardVideoPorts_public.Motherboards_Motherboard" FOREIGN KEY ("Motherboard_Id") REFERENCES public."Motherboards"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."MotherboardVideoPorts"
    ADD CONSTRAINT "FK_public.MotherboardVideoPorts_public.VideoPorts_VideoPort_Id" FOREIGN KEY ("VideoPort_Id") REFERENCES public."VideoPorts"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Motherboards"
    ADD CONSTRAINT "FK_public.Motherboards_public.AudioChipsets_AudioChipset_Id" FOREIGN KEY ("AudioChipset_Id") REFERENCES public."AudioChipsets"("Id");
ALTER TABLE ONLY public."Motherboards"
    ADD CONSTRAINT "FK_public.Motherboards_public.CPUSocket_CPUSocket_Id" FOREIGN KEY ("CPUSocket_Id") REFERENCES public."CPUSocket"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Motherboards"
    ADD CONSTRAINT "FK_public.Motherboards_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."Motherboards"
    ADD CONSTRAINT "FK_public.Motherboards_public.MotherboardChipsets_MotherboardCh" FOREIGN KEY ("MotherboardChipset_Id") REFERENCES public."MotherboardChipsets"("Id");
ALTER TABLE ONLY public."Motherboards"
    ADD CONSTRAINT "FK_public.Motherboards_public.MotherboardFormFactors_FormFactor" FOREIGN KEY ("FormFactor_Id") REFERENCES public."MotherboardFormFactors"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Motherboards"
    ADD CONSTRAINT "FK_public.Motherboards_public.NetworkAdapters_NetworkAdapter_Id" FOREIGN KEY ("NetworkAdapter_Id") REFERENCES public."NetworkAdapters"("Id");
ALTER TABLE ONLY public."Motherboards"
    ADD CONSTRAINT "FK_public.Motherboards_public.PCIEVersions_PCIEVersion_Id" FOREIGN KEY ("PCIEVersion_Id") REFERENCES public."PCIEVersions"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."MouseDPIModes"
    ADD CONSTRAINT "FK_public.MouseDPIModes_public.DPIModes_DPIMode_Id" FOREIGN KEY ("DPIMode_Id") REFERENCES public."DPIModes"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."MouseDPIModes"
    ADD CONSTRAINT "FK_public.MouseDPIModes_public.Mouses_Mouse_Id" FOREIGN KEY ("Mouse_Id") REFERENCES public."Mouses"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Mouses"
    ADD CONSTRAINT "FK_public.Mouses_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."NVMeSSDs"
    ADD CONSTRAINT "FK_public.NVMeSSDs_public.SSDs_Id" FOREIGN KEY ("Id") REFERENCES public."SSDs"("Id");
ALTER TABLE ONLY public."NetworkAdapters"
    ADD CONSTRAINT "FK_public.NetworkAdapters_public.SimpleComputerComponents_Id" FOREIGN KEY ("Id") REFERENCES public."SimpleComputerComponents"("Id");
ALTER TABLE ONLY public."OrderItems"
    ADD CONSTRAINT "FK_public.OrderItems_public.Items_ItemId" FOREIGN KEY ("ItemId") REFERENCES public."Items"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."OrderItems"
    ADD CONSTRAINT "FK_public.OrderItems_public.Orders_OrderId" FOREIGN KEY ("OrderId") REFERENCES public."Orders"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "FK_public.Orders_public.OrderStatus_OrderStatus_Id" FOREIGN KEY ("OrderStatus_Id") REFERENCES public."OrderStatus"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."Orders"
    ADD CONSTRAINT "FK_public.Orders_public.Users_Customer_Id" FOREIGN KEY ("Customer_Id") REFERENCES public."Users"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."PowerSupplies"
    ADD CONSTRAINT "FK_public.PowerSupplies_public.Certificates80Plus_Certificate80" FOREIGN KEY ("Certificate80Plus_Id") REFERENCES public."Certificates80Plus"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."PowerSupplies"
    ADD CONSTRAINT "FK_public.PowerSupplies_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."PreparedAssemblies"
    ADD CONSTRAINT "FK_public.PreparedAssemblies_public.CPUCoolers_CPUCooler_Id" FOREIGN KEY ("CPUCooler_Id") REFERENCES public."CPUCoolers"("Id");
ALTER TABLE ONLY public."PreparedAssemblies"
    ADD CONSTRAINT "FK_public.PreparedAssemblies_public.CPUs_CPU_Id" FOREIGN KEY ("CPU_Id") REFERENCES public."CPUs"("Id");
ALTER TABLE ONLY public."PreparedAssemblies"
    ADD CONSTRAINT "FK_public.PreparedAssemblies_public.ComputerCases_ComputerCase_" FOREIGN KEY ("ComputerCase_Id") REFERENCES public."ComputerCases"("Id");
ALTER TABLE ONLY public."PreparedAssemblies"
    ADD CONSTRAINT "FK_public.PreparedAssemblies_public.Displays_Display_Id" FOREIGN KEY ("Display_Id") REFERENCES public."Displays"("Id");
ALTER TABLE ONLY public."PreparedAssemblies"
    ADD CONSTRAINT "FK_public.PreparedAssemblies_public.GraphicsCards_GraphicsCard_" FOREIGN KEY ("GraphicsCard_Id") REFERENCES public."GraphicsCards"("Id");
ALTER TABLE ONLY public."PreparedAssemblies"
    ADD CONSTRAINT "FK_public.PreparedAssemblies_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."PreparedAssemblies"
    ADD CONSTRAINT "FK_public.PreparedAssemblies_public.Keyboards_Keyboard_Id" FOREIGN KEY ("Keyboard_Id") REFERENCES public."Keyboards"("Id");
ALTER TABLE ONLY public."PreparedAssemblies"
    ADD CONSTRAINT "FK_public.PreparedAssemblies_public.Motherboards_Motherboard_Id" FOREIGN KEY ("Motherboard_Id") REFERENCES public."Motherboards"("Id");
ALTER TABLE ONLY public."PreparedAssemblies"
    ADD CONSTRAINT "FK_public.PreparedAssemblies_public.Mouses_Mouse_Id" FOREIGN KEY ("Mouse_Id") REFERENCES public."Mouses"("Id");
ALTER TABLE ONLY public."PreparedAssemblies"
    ADD CONSTRAINT "FK_public.PreparedAssemblies_public.PowerSupplies_PowerSupply_I" FOREIGN KEY ("PowerSupply_Id") REFERENCES public."PowerSupplies"("Id");
ALTER TABLE ONLY public."PreparedAssemblyDiskDrives"
    ADD CONSTRAINT "FK_public.PreparedAssemblyDiskDrives_public.DiskDrives_DiskDriv" FOREIGN KEY ("DiskDrive_Id") REFERENCES public."DiskDrives"("Id");
ALTER TABLE ONLY public."PreparedAssemblyDiskDrives"
    ADD CONSTRAINT "FK_public.PreparedAssemblyDiskDrives_public.PreparedAssemblies_" FOREIGN KEY ("PreparedAssembly_Id") REFERENCES public."PreparedAssemblies"("Id");
ALTER TABLE ONLY public."PreparedAssemblyRAMs"
    ADD CONSTRAINT "FK_public.PreparedAssemblyRAMs_public.PreparedAssemblies_Prepar" FOREIGN KEY ("PreparedAssembly_Id") REFERENCES public."PreparedAssemblies"("Id");
ALTER TABLE ONLY public."PreparedAssemblyRAMs"
    ADD CONSTRAINT "FK_public.PreparedAssemblyRAMs_public.RAMs_RAM_Id" FOREIGN KEY ("RAM_Id") REFERENCES public."RAMs"("Id");
ALTER TABLE ONLY public."RAMs"
    ADD CONSTRAINT "FK_public.RAMs_public.Items_Id" FOREIGN KEY ("Id") REFERENCES public."Items"("Id");
ALTER TABLE ONLY public."RAMs"
    ADD CONSTRAINT "FK_public.RAMs_public.RAMTypes_RAMType_Id" FOREIGN KEY ("RAMType_Id") REFERENCES public."RAMTypes"("Id") ON DELETE CASCADE;
ALTER TABLE ONLY public."SSDControllers"
    ADD CONSTRAINT "FK_public.SSDControllers_public.SimpleComputerComponents_Id" FOREIGN KEY ("Id") REFERENCES public."SimpleComputerComponents"("Id");
ALTER TABLE ONLY public."SSDs"
    ADD CONSTRAINT "FK_public.SSDs_public.DiskDrives_Id" FOREIGN KEY ("Id") REFERENCES public."DiskDrives"("Id");
ALTER TABLE ONLY public."SSDs"
    ADD CONSTRAINT "FK_public.SSDs_public.SSDControllers_SSDController_Id" FOREIGN KEY ("SSDController_Id") REFERENCES public."SSDControllers"("Id");
ALTER TABLE ONLY public."SataSSDs"
    ADD CONSTRAINT "FK_public.SataSSDs_public.SSDs_Id" FOREIGN KEY ("Id") REFERENCES public."SSDs"("Id");
ALTER TABLE ONLY public."SimpleComputerComponents"
    ADD CONSTRAINT "FK_public.SimpleComputerComponents_public.SimpleComputerCompone" FOREIGN KEY ("Type_Id") REFERENCES public."SimpleComputerComponentTypes"("Id") ON DELETE CASCADE;
