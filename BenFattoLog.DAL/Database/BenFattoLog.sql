
CREATE TABLE "Log" (
    "Id" uuid NOT NULL,
    "Title" character varying(512),
    "OccurrenceeDate" timestamp with time zone,
    "Description" character varying(2048),
    "Source" character varying(512)    
);

ALTER TABLE "Log" OWNER TO microserv01;

ALTER TABLE ONLY "Log" ADD CONSTRAINT "Log_pkey" PRIMARY KEY ("Id");


