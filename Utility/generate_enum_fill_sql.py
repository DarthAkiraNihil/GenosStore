# INSERT INTO clients VALUES
#     (
#         DEFAULT,
#         'Макс Порох Всевластович',
#         DATE '2000-02-12',
#         2121,
#         685231
#         ),
#     (

tables = [
    "BankSystems",
    "Certificates80Plus",
    "ComputerCaseTypesizes",
    "CoolerMaterials",
    "DCPUSocket",
    "ItemTypes",
    "KeyboardType",
    "KeyboardTypesizes",
    "MatrixTypes",
    "OrderStatus",
    "PCIEVersions",
    "RAMTypes",
    "SimpleComputerComponentTypes",
    "Underlights",
    "VesaSizes",
    "VideoPorts",
    "MotherboardFormFactors",

]

values = {
    "BankSystems": [
        "Visa",
        "MasterCard",
        "UnionPay",
        "JBC",
        "Mir",
    ],
    "Certificates80Plus": [
        "Standard",
        "Bronze",
        "Silver",
        "Gold",
        "Platinum",
        "Titanium",
    ],
    "ComputerCaseTypesizes": [
        "MiniTower",
        "MidTower",
        "BigTower",
    ],
    "CoolerMaterials": [
        "Cooper",
        "Aluminium",
    ],
    "DCPUSocket": [
        "LGA1700",
        "LGA1200",
        "Socket4",
    ],
    "ItemTypes": [
        "CPU",
        "RAM",
        "Motherboard",
        "GraphicsCard",
        "PowerSupply",
        "HDD",
        "SataSSD",
        "NVMeSSD",
        "Display",
        "CPUCooler",
        "ComputerCase",
        "Keyboard",
        "Mouse",
        "PreparedAssembly",
    ],
    "KeyboardType": [
        "Optical",
        "Mechanic",
        "Membrane",
    ],
    "KeyboardTypesizes": [
        "TKL",
        "Percent60",
        "Full",
        "FullPlusNumpad",
    ],
    "MatrixTypes": [
        "TN",
        "IPS",
        "VA",
        "OLED",
    ],
    "OrderStatus": [
        "Created",
        "Confirmed",
        "AwaitsPayment",
        "Paid",
        "Processing",
        "Delivering",
        "Recieved",
        "Canceled",
    ],
    "PCIEVersions": [
        "4.0",
        "3.0",
    ],
    "RAMTypes": [
        "DDR4",
        "DDR5",
        "DDR3",
    ],
    "SimpleComputerComponentTypes": [
        "MotherboardChipset",
        "AudioChipset",
        "NetworkAdapter",
        "SSDController",
    ],
    "Underlights": [
        "LED",
        "CCFL",
        "RGB",
    ],
    "VesaSizes": [
        "Vesa100x100",
        "Vesa120x120",
    ],
    "VideoPorts": [
        "HDMI",
        "DisplayPort",
        "VGA",
        "DVI",
    ],
    "MotherboardFormFactors": [
        "mini-ATX",
        "ATX",
        "micro-ATX",
        "mini-ITX",
    ],
}

with open('enums.sql', 'w+', encoding='utf8') as f:
    for table in tables:
        print(f"Writing {table}")
        sql = f"INSERT INTO \"{table}\" VALUES "
        for idx in range(len(values[table]) - 1):
            sql += f"(DEFAULT, \'{values[table][idx]}\'), "
        sql += f"(DEFAULT, \'{values[table][-1]}\');\n"
        f.write(sql)

print("Done!")