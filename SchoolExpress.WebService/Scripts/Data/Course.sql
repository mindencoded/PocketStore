DELETE FROM Course
DBCC CHECKIDENT ('[Course]', RESEED, 0);
GO
SET IDENTITY_INSERT Course ON
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(1,   'UC-0001',  'Administraci�n I',											'#ff4000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(2,   'UC-0002',  'Econom�a',													'#ff8000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(3,   'UC-0003',  'Contabilidad I',											'#ffbf00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(4,   'UC-0004',  'Matem�tica I',												'#ffff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(5,   'UC-0005',  'Computaci�n I',												'#bfff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(6,   'UC-0006',  'Comunicaci�n I',											'#80ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(7,   'UC-0007',  'EFSRT I',													'#40ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(8,   'UC-0008',  'Administraci�n II',											'#00ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(9,   'UC-0009',  'Microeconom�a',												'#00ff40', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(10,  'UC-0010', 'Contabilidad II',											'#00ff80', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(11,  'UC-0011', 'Matem�tica II',												'#00ffbf', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(12,  'UC-0012', 'Computaci�n II',												'#00ffff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(13,  'UC-0013', 'Comunicaci�n II',											'#00bfff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(14,  'UC-0014', 'EFSRT II',													'#0080ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(15,  'UC-0015', 'Legislaci�n Empresarial',									'#0040ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(16,  'UC-0016', 'Macroeconom�a',												'#0000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(17,  'UC-0017', 'Costos',														'#4000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(18,  'UC-0018', 'Matem�tica Financiera',										'#8000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(19,  'UC-0019', 'Negocios Internacionales',									'#bf00ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(20,  'UC-0020', 'Desarrollo Personal',										'#ff00ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(21,  'UC-0021', 'EFSRT III',													'#ff00bf', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(22,  'UC-0022', 'Presupuestos',												'#ff0080', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(23,  'UC-0023', 'Finanzas',													'#ff0040', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(24,  'UC-0024', 'Marketing',													'#ff0000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(25,  'UC-0025', 'Log�stica',													'#ff4000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(26,  'UC-0026', 'Estad�stica I',												'#ff8000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(27,  'UC-0027', 'Taller de Liderazgo y Trabajo en Equipo',					'#ffbf00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(28,  'UC-0028', 'EFSRT IV',													'#ffff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(29,  'UC-0029', 'Recursos Humanos',											'#bfff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(30,  'UC-0030', 'Proyectos de Inversi�n',										'#80ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(31,  'UC-0031', 'T�cnicas de Ventas',											'#40ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(32,  'UC-0032', 'Gesti�n Aduanera',											'#00ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(33,  'UC-0033', 'Estad�stica II',												'#00ff40', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(34,  'UC-0034', 'Taller de Empleabilidad',									'#00ff80', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(35,  'UC-0035', 'EFSRT V',													'#00ffbf', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(36,  'UC-0036', 'Marketing de Exportaciones',									'#00ffff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(37,  'UC-0037', 'Administraci�n Estrat�gica',									'#00bfff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(38,  'UC-0038', 'Administraci�n P�blica',										'#0080ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(39,  'UC-0039', 'Trabajo de Investigaci�n',									'#0040ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(40,  'UC-0040', 'Taller de Emprendimiento',									'#0000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(41,  'UC-0041', 'EFSRT VI',													'#4000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(42,  'UC-0042', 'Legislaci�n de Sociedades',									'#8000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(43,  'UC-0043', 'Plan Contable',												'#bf00ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(44,  'UC-0044', 'Matem�tica',													'#ff00ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(45,  'UC-0045', 'Contabilidad Financiera I',									'#ff00bf', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(46,  'UC-0046', 'Administraci�n General',										'#ff0080', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(47,  'UC-0047', 'Contabilidad Financiera II',									'#ff0040', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(48,  'UC-0048', 'Legislaci�n Laboral',										'#ff0000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(49,  'UC-0049', 'T�cnica Contable I',											'#ff4000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(50,  'UC-0050', 'Legislaci�n Tributaria',										'#ff8000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(51,  'UC-0051', 'Contabilidad de Costos',										'#ffbf00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(52,  'UC-0052', 'T�cnica Contable II',										'#ffff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(53,  'UC-0053', 'Contabilidad de Sociedades',									'#bfff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(54,  'UC-0054', 'Estad�stica General',										'#80ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(55,  'UC-0055', 'Formulaci�n de Estados Financieros',							'#40ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(56,  'UC-0056', 'Normas de Informaci�n Financiera',							'#00ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(57,  'UC-0057', 'Auditor�a I',												'#00ff40', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(58,  'UC-0058', 'Inform�tica Contable',										'#00ff80', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(59,  'UC-0059', 'Laboratorio Contable',										'#00ffbf', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(60,  'UC-0060', 'Auditor�a II',												'#00ffff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(61,  'UC-0061', 'An�lisis e Interpretaci�n de Estados Financieros',			'#00bfff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(62,  'UC-0062', 'Econom�a para los Negocios',									'#0080ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(63,  'UC-0063', 'M�todos Cuantitativos para los Negocios',					'#0040ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(64,  'UC-0064', 'Contabilidad Gerencial',										'#0000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(65,  'UC-0065', 'Direcci�n Estrat�gica I' ,									'#4000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(66,  'UC-0066', 'Direcci�n Estrat�gica del Capital Humano',					'#8000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(67,  'UC-0067', 'Sistemas y Gesti�n de Tecnolog�as de Informaci�n',			'#bf00ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(68,  'UC-0068', 'Seminario de Tesis',											'#ff00ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(69,  'UC-0069', 'Taller de Investigaci�n I',									'#ff00bf', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(70,  'UC-0070', 'Globalizaci�n y Empresas',									'#ff0080', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(71,  'UC-0071', 'Direcci�n Estrat�gica del Marketing',						'#ff0040', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(72,  'UC-0072', 'Direcci�n Estrat�gica de las Finanzas',						'#ff0000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(73,  'UC-0073', 'Direcci�n Estrat�gica de Operaciones',						'#ff4000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(74,  'UC-0074', '�tica de la Empresa y Responsabilidad Social',				'#ff8000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(75,  'UC-0075', 'Habilidades Directivas',										'#ffbf00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(76,  'UC-0076', 'Direcci�n Estrat�gica II',									'#ffff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(77,  'UC-0077', 'Taller de Investigaci�n II',									'#bfff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(78,  'UC-0078', 'Direcci�n Estrat�gica del Sistema de Informaci�n',			'#80ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(79,  'UC-0079', 'Business Process Management',								'#40ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(80,  'UC-0080', 'Sistemas de Informaci�n Empresarial',						'#00ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(81,  'UC-0081', 'Inteligencia de Negocios',									'#00ff40', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(82,  'UC-0082', 'Auditor�a de los Sistemas de Informaci�n',					'#00ff80', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(83,  'UC-0083', 'Gesti�n de las Tecnolog�as de Informaci�n',					'#00ffbf', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(84,  'UC-0084', 'Prospecci�n de Tecnolog�as Emergentes',						'#00ffff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(85,  'UC-0085', 'Gesti�n Financiera de Proyectos de TI',						'#00bfff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(86,  'UC-0086', 'Gesti�n de eBusiness',										'#0080ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(87,  'UC-0087', 'Seguridad Inform�tica',										'#0040ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(88,  'UC-0088', 'Gerencia de Proyectos con Metodolog�a PMI',					'#0000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(89,  'UC-0089', 'Planificaci�n de Proyectos con Metodolog�a PMI',				'#4000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(90,  'UC-0090', 'Ejecuci�n de Proyecto con Metodolog�a PMI',					'#8000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(91,  'UC-0091', 'Control del Proyecto con Metodolog�a PMI',					'#bf00ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(92,  'UC-0092', 'Cierre del Proyecto con Metodolog�a PMI',					'#ff00ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(93,  'UC-0093', 'Seminario Internacional',									'#ff00bf', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(94,  'UC-0094', 'Derecho Constitucional Empresarial',							'#ff0080', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(95,  'UC-0095', 'Derecho de Sociedades',										'#ff0040', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(96,  'UC-0096', 'Contratos Modernos',											'#ff0000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(97,  'UC-0097', 'Derecho Laboral',											'#ff4000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(98,  'UC-0098', 'Soluci�n de Conflictos Empresariales',						'#ff8000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(99,  'UC-0099', 'Derecho de la Libre Competencia',							'#ffbf00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(100, 'UC-0100', 'Derecho del Consumidor',										'#ffff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(101, 'UC-0101', 'Propiedad Intelectual',										'#bfff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(102, 'UC-0102', 'Conciliaci�n y Arbitraje',									'#80ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(103, 'UC-0103', 'Derecho Penal Empresarial',									'#40ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(104, 'UC-0104', 'C�digo Tributario',											'#00ff00', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(105, 'UC-0105', 'Impuesto a la Renta',										'#00ff40', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(106, 'UC-0106', 'Impuesto a las Ventas y el ISC',								'#00ff80', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(107, 'UC-0107', 'Impuestos Aduaneros',										'#00ffbf', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(108, 'UC-0108', 'Tributaci�n Municipal',										'#00ffff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(109, 'UC-0109', 'Econom�a y Entorno de los Proyectos Mineros',				'#00bfff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(110, 'UC-0110', 'Legislaci�n Aplicable a los Proyectos Mineros',				'#0080ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(111, 'UC-0111', 'Planeamiento de Proyectos de Inversi�n Minera',				'#0040ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(112, 'UC-0112', 'Evaluaci�n de Proyectos de Inversi�n Minera',				'#0000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(113, 'UC-0113', 'An�lisis del Riesgo de Proyectos Mineros',					'#4000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(114, 'UC-0114', 'Gesti�n de Operaciones Mineras',								'#8000ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(115, 'UC-0115', 'Gesti�n de Personas en Operaciones Mineras',					'#bf00ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(116, 'UC-0116', 'Gesti�n Log�stica en Operaciones Mineras',					'#ff00ff', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(117, 'UC-0117', 'Direcci�n Estrat�gica de Empresas Mineras',					'#ff00bf', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(118, 'UC-0118', 'Gesti�n de Seguridad y Salud Ocupacional',					'#ff0080', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(119, 'UC-0119', 'Metodolog�a de Evaluaci�n del Impacto Ambiental',			'#ff0040', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(120, 'UC-0120', 'Aseguramiento Ambiental ISO 14000',							'#ff0000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(121, 'UC-0121', 'Negociaci�n y Manejo de Conflictos',							'#ff4000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(122, 'UC-0122', 'Modelos y Herramientas para las Relaciones Comunitarias',	'#ff8000', GETDATE(), GETDATE(), 1)
insert into Course (Id, Code, Description, BackgroundColor, LastModified, Created, Status) values(123, 'UC-0123', 'Aseguramiento de la RSE ISO 26000',							'#ffbf00', GETDATE(), GETDATE(), 1)
SET IDENTITY_INSERT Course OFF








































































