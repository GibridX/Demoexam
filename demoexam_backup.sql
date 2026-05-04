--
-- PostgreSQL database dump
--

\restrict fizgSqGrcrXcTRTqIks42FjVaQhRrHIeRErXayMQ1lHALVfCqqbhHHWO7EnOIkF

-- Dumped from database version 16.13
-- Dumped by pg_dump version 18.2

-- Started on 2026-05-04 22:36:50

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 4 (class 2615 OID 2200)
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- TOC entry 4927 (class 0 OID 0)
-- Dependencies: 4
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 220 (class 1259 OID 16453)
-- Name: orders; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.orders (
    order_id integer NOT NULL,
    order_article character varying(25) NOT NULL,
    order_date date NOT NULL,
    delivery_date date NOT NULL,
    pickup_point_id integer NOT NULL,
    client_full_name character varying(150),
    pickup_code integer NOT NULL,
    status character varying(20) DEFAULT 'Новый'::character varying,
    CONSTRAINT orders_status_check CHECK (((status)::text = ANY ((ARRAY['Новый'::character varying, 'В обработке'::character varying, 'Завершен'::character varying, 'Отменен'::character varying])::text[])))
);


ALTER TABLE public.orders OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16445)
-- Name: pickup_points; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.pickup_points (
    id integer NOT NULL,
    address text NOT NULL
);


ALTER TABLE public.pickup_points OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16444)
-- Name: pickup_points_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.pickup_points_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.pickup_points_id_seq OWNER TO postgres;

--
-- TOC entry 4928 (class 0 OID 0)
-- Dependencies: 218
-- Name: pickup_points_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.pickup_points_id_seq OWNED BY public.pickup_points.id;


--
-- TOC entry 217 (class 1259 OID 16430)
-- Name: production; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.production (
    article character varying(25) NOT NULL,
    name character varying(200) NOT NULL,
    unit character varying(50) DEFAULT 'шт.'::character varying,
    price numeric(10,2) NOT NULL,
    supplier character varying(100),
    manufacturer character varying(100),
    category character varying(100),
    discount integer DEFAULT 0,
    stock_quantity integer DEFAULT 0,
    description text,
    photo character varying(255) DEFAULT 'picture.png'::character varying,
    CONSTRAINT production_discount_check CHECK (((discount >= 0) AND (discount <= 100))),
    CONSTRAINT production_price_check CHECK ((price >= (0)::numeric)),
    CONSTRAINT production_stock_quantity_check CHECK ((stock_quantity >= 0))
);


ALTER TABLE public.production OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16419)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id integer NOT NULL,
    role character varying(50) NOT NULL,
    full_name character varying(150) NOT NULL,
    login character varying(50) NOT NULL,
    password character varying(255) NOT NULL,
    CONSTRAINT users_role_check CHECK (((role)::text = ANY ((ARRAY['Администратор'::character varying, 'Менеджер'::character varying, 'Авторизированный клиент'::character varying])::text[])))
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16418)
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_id_seq OWNER TO postgres;

--
-- TOC entry 4929 (class 0 OID 0)
-- Dependencies: 215
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- TOC entry 4753 (class 2604 OID 16448)
-- Name: pickup_points id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pickup_points ALTER COLUMN id SET DEFAULT nextval('public.pickup_points_id_seq'::regclass);


--
-- TOC entry 4748 (class 2604 OID 16422)
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- TOC entry 4921 (class 0 OID 16453)
-- Dependencies: 220
-- Data for Name: orders; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.orders (order_id, order_article, order_date, delivery_date, pickup_point_id, client_full_name, pickup_code, status) FROM stdin;
1	А112Т4, 2, F635R4, 2	2025-02-27	2025-04-20	1	Степанов Михаил Артёмович	901	Завершен
2	H782T5, 1, G783F5, 1	2022-09-28	2025-04-21	11	Никифорова Весения Николаевна	902	Завершен
3	J384T6, 10, D572U8, 10	2025-03-21	2025-04-22	2	Сазонов Руслан Германович	903	Завершен
4	F572H7, 5, D329H3, 4	2025-02-20	2025-04-23	11	Одинцов Серафим Артёмович	904	Завершен
5	А112Т4, 2, F635R4, 2	2025-03-17	2025-04-24	2	Степанов Михаил Артёмович	905	Завершен
6	H782T5, 1, G783F5, 1	2025-03-01	2025-04-25	15	Никифорова Весения Николаевна	906	Завершен
7	J384T6, 10, D572U8, 10	2025-02-24	2025-04-26	3	Сазонов Руслан Германович	907	Завершен
8	F572H7, 5, D329H3, 4	2025-03-31	2025-04-27	19	Одинцов Серафим Артёмович	908	Новый
9	B320R5, 5, G432E4, 1	2025-04-02	2025-04-28	5	Степанов Михаил Артёмович	909	Новый
10	S213E3, 5, E482R4, 5	2025-04-03	2025-04-29	19	Степанов Михаил Артёмович	910	Новый
\.


--
-- TOC entry 4920 (class 0 OID 16445)
-- Dependencies: 219
-- Data for Name: pickup_points; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.pickup_points (id, address) FROM stdin;
1	125061, г. Лесной, ул. Подгорная, 8
2	630370, г. Лесной, ул. Шоссейная, 24
3	400562, г. Лесной, ул. Зеленая, 32
4	614510, г. Лесной, ул. Маяковского, 47
5	410542, г. Лесной, ул. Светлая, 46
6	620839, г. Лесной, ул. Цветочная, 8
7	443890, г. Лесной, ул. Коммунистическая, 1
8	603379, г. Лесной, ул. Спортивная, 46
9	603721, г. Лесной, ул. Гоголя, 41
10	410172, г. Лесной, ул. Северная, 13
11	614611, г. Лесной, ул. Молодежная, 50
12	454311, г.Лесной, ул. Новая, 19
13	660007, г.Лесной, ул. Октябрьская, 19
14	603036, г. Лесной, ул. Садовая, 4
15	394060, г.Лесной, ул. Фрунзе, 43
16	410661, г. Лесной, ул. Школьная, 50
17	625590, г. Лесной, ул. Коммунистическая, 20
18	625683, г. Лесной, ул. 8 Марта
19	450983, г.Лесной, ул. Комсомольская, 26
20	394782, г. Лесной, ул. Чехова, 3
21	603002, г. Лесной, ул. Дзержинского, 28
22	450558, г. Лесной, ул. Набережная, 30
23	344288, г. Лесной, ул. Чехова, 1
24	614164, г.Лесной,  ул. Степная, 30
25	394242, г. Лесной, ул. Коммунистическая, 43
26	660540, г. Лесной, ул. Солнечная, 25
27	125837, г. Лесной, ул. Шоссейная, 40
28	125703, г. Лесной, ул. Партизанская, 49
29	625283, г. Лесной, ул. Победы, 46
30	614753, г. Лесной, ул. Полевая, 35
31	426030, г. Лесной, ул. Маяковского, 44
32	450375, г. Лесной ул. Клубная, 44
33	625560, г. Лесной, ул. Некрасова, 12
34	630201, г. Лесной, ул. Комсомольская, 17
35	190949, г. Лесной, ул. Мичурина, 26
\.


--
-- TOC entry 4918 (class 0 OID 16430)
-- Dependencies: 217
-- Data for Name: production; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.production (article, name, unit, price, supplier, manufacturer, category, discount, stock_quantity, description, photo) FROM stdin;
А112Т4	Ботинки	шт.	4990.00	Kari	Kari	Женская обувь	3	6	Женские Ботинки демисезонные kari	1.jpg
F635R4	Ботинки	шт.	3244.00	Обувь для вас	Marco Tozzi	Женская обувь	2	13	Ботинки Marco Tozzi женские демисезонные, размер 39, цвет бежевый	2.jpg
H782T5	Туфли	шт.	4499.00	Kari	Kari	Мужская обувь	4	5	Туфли kari мужские классика MYZ21AW-450A, размер 43, цвет: черный	3.jpg
G783F5	Ботинки	шт.	5900.00	Kari	Рос	Мужская обувь	2	8	Мужские ботинки Рос-Обувь кожаные с натуральным мехом	4.jpg
J384T6	Ботинки	шт.	3800.00	Обувь для вас	Rieker	Мужская обувь	2	16	B3430/14 Полуботинки мужские Rieker	5.jpg
D572U8	Кроссовки	шт.	4100.00	Обувь для вас	Рос	Мужская обувь	3	6	129615-4 Кроссовки мужские	6.jpg
F572H7	Туфли	шт.	2700.00	Kari	Marco Tozzi	Женская обувь	2	14	Туфли Marco Tozzi женские летние, размер 39, цвет черный	7.jpg
D329H3	Полуботинки	шт.	1890.00	Обувь для вас	Alessio Nesca	Женская обувь	4	4	Полуботинки Alessio Nesca женские 3-30797-47, размер 37, цвет: бордовый	8.jpg
B320R5	Туфли	шт.	4300.00	Kari	Rieker	Женская обувь	2	6	Туфли Rieker женские демисезонные, размер 41, цвет коричневый	9.jpg
G432E4	Туфли	шт.	2800.00	Kari	Kari	Женская обувь	3	15	Туфли kari женские TR-YR-413017, размер 37, цвет: черный	10.jpg
S213E3	Полуботинки	шт.	2156.00	Обувь для вас	CROSBY	Мужская обувь	3	6	407700/01-01 Полуботинки мужские CROSBY	\N
E482R4	Полуботинки	шт.	1800.00	Kari	Kari	Женская обувь	2	14	Полуботинки kari женские MYZ20S-149, размер 41, цвет: черный	\N
S634B5	Кеды	шт.	5500.00	Обувь для вас	CROSBY	Мужская обувь	3	0	Кеды Caprice мужские демисезонные, размер 42, цвет черный	\N
K345R4	Полуботинки	шт.	2100.00	Обувь для вас	CROSBY	Мужская обувь	2	3	407700/01-02 Полуботинки мужские CROSBY	\N
O754F4	Туфли	шт.	5400.00	Обувь для вас	Rieker	Женская обувь	4	18	Туфли женские демисезонные Rieker артикул 55073-68/37	\N
G531F4	Ботинки	шт.	6600.00	Kari	Kari	Женская обувь	12	9	Ботинки женские зимние ROMER арт. 893167-01 Черный	\N
J542F5	Тапочки	шт.	500.00	Kari	Kari	Мужская обувь	13	0	Тапочки мужские Арт.70701-55-67син р.41	\N
B431R5	Ботинки	шт.	2700.00	Обувь для вас	Rieker	Мужская обувь	2	5	Мужские кожаные ботинки/мужские ботинки	\N
P764G4	Туфли	шт.	6800.00	Kari	CROSBY	Женская обувь	15	15	Туфли женские, ARGO, размер 38	\N
C436G5	Ботинки	шт.	10200.00	Kari	Alessio Nesca	Женская обувь	15	9	Ботинки женские, ARGO, размер 40	\N
F427R5	Ботинки	шт.	11800.00	Обувь для вас	Rieker	Женская обувь	15	11	Ботинки на молнии с декоративной пряжкой FRAU	\N
N457T5	Полуботинки	шт.	4600.00	Kari	CROSBY	Женская обувь	3	13	Полуботинки Ботинки черные зимние, мех	\N
D364R4	Туфли	шт.	12400.00	Kari	Kari	Женская обувь	16	5	Туфли Luiza Belly женские Kate-lazo черные из натуральной замши	\N
S326R5	Тапочки	шт.	9900.00	Обувь для вас	CROSBY	Мужская обувь	17	15	Мужские кожаные тапочки "Профиль С.Дали" 	\N
L754R4	Полуботинки	шт.	1700.00	Kari	Kari	Женская обувь	2	7	Полуботинки kari женские WB2020SS-26, размер 38, цвет: черный	\N
M542T5	Кроссовки	шт.	2800.00	Обувь для вас	Rieker	Мужская обувь	18	3	Кроссовки мужские TOFA	\N
D268G5	Туфли	шт.	4399.00	Обувь для вас	Rieker	Женская обувь	3	12	Туфли Rieker женские демисезонные, размер 36, цвет коричневый	\N
T324F5	Сапоги	шт.	4699.00	Kari	CROSBY	Женская обувь	2	5	Сапоги замша Цвет: синий	\N
K358H6	Тапочки	шт.	599.00	Kari	Rieker	Мужская обувь	20	2	Тапочки мужские син р.41	\N
H535R5	Ботинки	шт.	2300.00	Обувь для вас	Rieker	Женская обувь	2	7	Женские Ботинки демисезонные	\N
\.


--
-- TOC entry 4917 (class 0 OID 16419)
-- Dependencies: 216
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, role, full_name, login, password) FROM stdin;
1	Администратор	Никифорова Весения Николаевна	94d5ous@gmail.com	uzWC67
2	Администратор	Сазонов Руслан Германович	uth4iz@mail.com	2L6KZG
3	Администратор	Одинцов Серафим Артёмович	yzls62@outlook.com	JlFRCZ
4	Менеджер	Степанов Михаил Артёмович	1diph5e@tutanota.com	8ntwUp
5	Менеджер	Ворсин Петр Евгеньевич	tjde7c@yahoo.com	YOyhfR
6	Менеджер	Старикова Елена Павловна	wpmrc3do@tutanota.com	RSbvHv
7	Авторизированный клиент	Михайлюк Анна Вячеславовна	5d4zbu@tutanota.com	rwVDh9
8	Авторизированный клиент	Ситдикова Елена Анатольевна	ptec8ym@yahoo.com	LdNyos
9	Авторизированный клиент	Ворсин Петр Евгеньевич	1qz4kw@mail.com	gynQMT
10	Авторизированный клиент	Старикова Елена Павловна	4np6se@mail.com	AtnDjr
\.


--
-- TOC entry 4930 (class 0 OID 0)
-- Dependencies: 218
-- Name: pickup_points_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.pickup_points_id_seq', 35, true);


--
-- TOC entry 4931 (class 0 OID 0)
-- Dependencies: 215
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 10, true);


--
-- TOC entry 4769 (class 2606 OID 16461)
-- Name: orders orders_pickup_code_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_pickup_code_key UNIQUE (pickup_code);


--
-- TOC entry 4771 (class 2606 OID 16459)
-- Name: orders orders_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_pkey PRIMARY KEY (order_id);


--
-- TOC entry 4767 (class 2606 OID 16452)
-- Name: pickup_points pickup_points_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pickup_points
    ADD CONSTRAINT pickup_points_pkey PRIMARY KEY (id);


--
-- TOC entry 4765 (class 2606 OID 16443)
-- Name: production production_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.production
    ADD CONSTRAINT production_pkey PRIMARY KEY (article);


--
-- TOC entry 4761 (class 2606 OID 16429)
-- Name: users users_login_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_login_key UNIQUE (login);


--
-- TOC entry 4763 (class 2606 OID 16427)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- TOC entry 4772 (class 2606 OID 16462)
-- Name: orders orders_pickup_point_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.orders
    ADD CONSTRAINT orders_pickup_point_id_fkey FOREIGN KEY (pickup_point_id) REFERENCES public.pickup_points(id);


-- Completed on 2026-05-04 22:36:50

--
-- PostgreSQL database dump complete
--

\unrestrict fizgSqGrcrXcTRTqIks42FjVaQhRrHIeRErXayMQ1lHALVfCqqbhHHWO7EnOIkF

