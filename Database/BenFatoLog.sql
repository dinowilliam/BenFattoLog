--
-- PostgreSQL database dump
--

-- Dumped from database version 13.1 (Debian 13.1-1.pgdg100+1)
-- Dumped by pg_dump version 13.1

-- Started on 2020-12-13 03:21:19
-- Database: BenFattoLog

-- DROP DATABASE "BenFattoLog";

CREATE DATABASE "BenFattoLog"
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 200 (class 1259 OID 16385)
-- Name: Log; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Log" (
    "Id" uuid NOT NULL,
    "IpAddress" inet NOT NULL,
    "OccurrenceeDate" timestamp with time zone,
    "AccessLog" character varying(2048),
    "HttpResponse" smallint,
    "Port" integer,
    "AddDate" timestamp with time zone
);


ALTER TABLE public."Log" OWNER TO postgres;

--
-- TOC entry 2803 (class 2606 OID 16392)
-- Name: Log Log_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Log"
    ADD CONSTRAINT "Log_pkey" PRIMARY KEY ("Id");


-- Completed on 2020-12-13 03:21:19

--
-- PostgreSQL database dump complete
--

