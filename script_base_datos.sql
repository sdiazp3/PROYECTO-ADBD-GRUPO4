-- DROP SCHEMA public;

CREATE SCHEMA public AUTHORIZATION pg_database_owner;

COMMENT ON SCHEMA public IS 'standard public schema';

-- DROP SEQUENCE public.asignacion_id_asignacion_seq;

CREATE SEQUENCE public.asignacion_id_asignacion_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.asignatura_id_asignatura_seq;

CREATE SEQUENCE public.asignatura_id_asignatura_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.carrera_id_carrera_seq;

CREATE SEQUENCE public.carrera_id_carrera_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.convocatoria_id_convocatoria_seq;

CREATE SEQUENCE public.convocatoria_id_convocatoria_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.facultad_id_facultad_seq;

CREATE SEQUENCE public.facultad_id_facultad_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.periodo_academico_id_periodo_seq;

CREATE SEQUENCE public.periodo_academico_id_periodo_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.postulacion_id_postulacion_seq;

CREATE SEQUENCE public.postulacion_id_postulacion_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.registro_horas_id_registro_seq;

CREATE SEQUENCE public.registro_horas_id_registro_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.usuario_id_usuario_seq;

CREATE SEQUENCE public.usuario_id_usuario_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 2147483647
	START 1
	CACHE 1
	NO CYCLE;-- public.facultad definition

-- Drop table

-- DROP TABLE public.facultad;

CREATE TABLE public.facultad (
	id_facultad int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	nombre varchar(150) NOT NULL,
	activo bool DEFAULT true NOT NULL,
	CONSTRAINT ck_facultad_nombre CHECK ((btrim((nombre)::text) <> ''::text)),
	CONSTRAINT facultad_activo_not_null NOT NULL activo,
	CONSTRAINT facultad_id_facultad_not_null NOT NULL id_facultad,
	CONSTRAINT facultad_nombre_key UNIQUE (nombre),
	CONSTRAINT facultad_nombre_not_null NOT NULL nombre,
	CONSTRAINT facultad_pkey PRIMARY KEY (id_facultad)
);
COMMENT ON TABLE public.facultad IS 'Facultades de la institución.';


-- public.periodo_academico definition

-- Drop table

-- DROP TABLE public.periodo_academico;

CREATE TABLE public.periodo_academico (
	id_periodo int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	nombre varchar(60) NOT NULL,
	fecha_inicio date NOT NULL,
	fecha_fin date NOT NULL,
	activo bool DEFAULT true NOT NULL,
	CONSTRAINT ck_periodo_fechas CHECK ((fecha_fin > fecha_inicio)),
	CONSTRAINT periodo_academico_activo_not_null NOT NULL activo,
	CONSTRAINT periodo_academico_fecha_fin_not_null NOT NULL fecha_fin,
	CONSTRAINT periodo_academico_fecha_inicio_not_null NOT NULL fecha_inicio,
	CONSTRAINT periodo_academico_id_periodo_not_null NOT NULL id_periodo,
	CONSTRAINT periodo_academico_nombre_key UNIQUE (nombre),
	CONSTRAINT periodo_academico_nombre_not_null NOT NULL nombre,
	CONSTRAINT periodo_academico_pkey PRIMARY KEY (id_periodo)
);
COMMENT ON TABLE public.periodo_academico IS 'Períodos académicos en los que se convocan ayudantías.';


-- public.rol definition

-- Drop table

-- DROP TABLE public.rol;

CREATE TABLE public.rol (
	id_rol int4 NOT NULL,
	nombre varchar(30) NOT NULL,
	CONSTRAINT rol_id_rol_not_null NOT NULL id_rol,
	CONSTRAINT rol_nombre_key UNIQUE (nombre),
	CONSTRAINT rol_nombre_not_null NOT NULL nombre,
	CONSTRAINT rol_pkey PRIMARY KEY (id_rol)
);
COMMENT ON TABLE public.rol IS 'Roles: Administrador, Coordinador, Docente y Estudiante.';


-- public.carrera definition

-- Drop table

-- DROP TABLE public.carrera;

CREATE TABLE public.carrera (
	id_carrera int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	id_facultad int4 NOT NULL,
	nombre varchar(150) NOT NULL,
	activo bool DEFAULT true NOT NULL,
	CONSTRAINT carrera_activo_not_null NOT NULL activo,
	CONSTRAINT carrera_id_carrera_not_null NOT NULL id_carrera,
	CONSTRAINT carrera_id_facultad_not_null NOT NULL id_facultad,
	CONSTRAINT carrera_nombre_not_null NOT NULL nombre,
	CONSTRAINT carrera_pkey PRIMARY KEY (id_carrera),
	CONSTRAINT ck_carrera_nombre CHECK ((btrim((nombre)::text) <> ''::text)),
	CONSTRAINT uq_carrera UNIQUE (id_facultad, nombre),
	CONSTRAINT carrera_id_facultad_fkey FOREIGN KEY (id_facultad) REFERENCES public.facultad(id_facultad)
);
CREATE INDEX ix_carrera_facultad ON public.carrera USING btree (id_facultad);
COMMENT ON TABLE public.carrera IS 'Carreras de cada facultad.';


-- public.usuario definition

-- Drop table

-- DROP TABLE public.usuario;

CREATE TABLE public.usuario (
	id_usuario int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	cedula varchar(10) NOT NULL, -- Cédula ecuatoriana de 10 dígitos, única.
	nombres varchar(80) NOT NULL,
	apellidos varchar(80) NOT NULL,
	correo varchar(120) NOT NULL, -- Correo institucional, único sin distinguir mayúsculas.
	contrasena_hash text NOT NULL, -- Contraseña cifrada con bcrypt (pgcrypto). Nunca en texto plano.
	id_rol int4 NOT NULL,
	id_carrera int4 NULL, -- Obligatoria para coordinadores y estudiantes.
	activo bool DEFAULT true NOT NULL, -- Un usuario desactivado no puede iniciar sesión.
	fecha_registro timestamp DEFAULT now() NOT NULL,
	CONSTRAINT ck_usuario_carrera CHECK (((id_rol <> ALL (ARRAY[2, 4])) OR (id_carrera IS NOT NULL))),
	CONSTRAINT ck_usuario_cedula CHECK (((cedula)::text ~ '^[0-9]{10}$'::text)),
	CONSTRAINT ck_usuario_correo CHECK (((correo)::text ~* '^[^@[:space:]]+@[^@[:space:]]+\.[^@[:space:]]+$'::text)),
	CONSTRAINT ck_usuario_hash CHECK ((contrasena_hash ~~ '$2%'::text)),
	CONSTRAINT usuario_activo_not_null NOT NULL activo,
	CONSTRAINT usuario_apellidos_not_null NOT NULL apellidos,
	CONSTRAINT usuario_cedula_key UNIQUE (cedula),
	CONSTRAINT usuario_cedula_not_null NOT NULL cedula,
	CONSTRAINT usuario_contrasena_hash_not_null NOT NULL contrasena_hash,
	CONSTRAINT usuario_correo_not_null NOT NULL correo,
	CONSTRAINT usuario_fecha_registro_not_null NOT NULL fecha_registro,
	CONSTRAINT usuario_id_rol_not_null NOT NULL id_rol,
	CONSTRAINT usuario_id_usuario_not_null NOT NULL id_usuario,
	CONSTRAINT usuario_nombres_not_null NOT NULL nombres,
	CONSTRAINT usuario_pkey PRIMARY KEY (id_usuario),
	CONSTRAINT usuario_id_carrera_fkey FOREIGN KEY (id_carrera) REFERENCES public.carrera(id_carrera),
	CONSTRAINT usuario_id_rol_fkey FOREIGN KEY (id_rol) REFERENCES public.rol(id_rol)
);
CREATE INDEX ix_usuario_carrera ON public.usuario USING btree (id_carrera);
CREATE UNIQUE INDEX ux_usuario_correo ON public.usuario USING btree (lower((correo)::text));
COMMENT ON TABLE public.usuario IS 'Usuarios del sistema con su rol.';

-- Column comments

COMMENT ON COLUMN public.usuario.cedula IS 'Cédula ecuatoriana de 10 dígitos, única.';
COMMENT ON COLUMN public.usuario.correo IS 'Correo institucional, único sin distinguir mayúsculas.';
COMMENT ON COLUMN public.usuario.contrasena_hash IS 'Contraseña cifrada con bcrypt (pgcrypto). Nunca en texto plano.';
COMMENT ON COLUMN public.usuario.id_carrera IS 'Obligatoria para coordinadores y estudiantes.';
COMMENT ON COLUMN public.usuario.activo IS 'Un usuario desactivado no puede iniciar sesión.';


-- public.asignatura definition

-- Drop table

-- DROP TABLE public.asignatura;

CREATE TABLE public.asignatura (
	id_asignatura int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	id_carrera int4 NOT NULL,
	codigo varchar(20) NOT NULL,
	nombre varchar(150) NOT NULL,
	nivel int4 NOT NULL,
	activo bool DEFAULT true NOT NULL,
	CONSTRAINT asignatura_activo_not_null NOT NULL activo,
	CONSTRAINT asignatura_codigo_not_null NOT NULL codigo,
	CONSTRAINT asignatura_id_asignatura_not_null NOT NULL id_asignatura,
	CONSTRAINT asignatura_id_carrera_not_null NOT NULL id_carrera,
	CONSTRAINT asignatura_nivel_not_null NOT NULL nivel,
	CONSTRAINT asignatura_nombre_not_null NOT NULL nombre,
	CONSTRAINT asignatura_pkey PRIMARY KEY (id_asignatura),
	CONSTRAINT ck_asignatura_nivel CHECK (((nivel >= 1) AND (nivel <= 12))),
	CONSTRAINT uq_asignatura UNIQUE (id_carrera, codigo),
	CONSTRAINT asignatura_id_carrera_fkey FOREIGN KEY (id_carrera) REFERENCES public.carrera(id_carrera)
);
CREATE INDEX ix_asignatura_carrera ON public.asignatura USING btree (id_carrera);
COMMENT ON TABLE public.asignatura IS 'Asignaturas de cada carrera.';


-- public.convocatoria definition

-- Drop table

-- DROP TABLE public.convocatoria;

CREATE TABLE public.convocatoria (
	id_convocatoria int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	id_asignatura int4 NOT NULL,
	id_periodo int4 NOT NULL,
	id_coordinador int4 NOT NULL,
	cupos int4 NOT NULL, -- Número máximo de ayudantes (1 a 50).
	horas_requeridas int4 NOT NULL, -- Horas que debe cumplir cada ayudante.
	requisitos text NOT NULL,
	fecha_desde date NOT NULL, -- Primer día para postularse.
	fecha_hasta date NOT NULL, -- Último día para postularse.
	fecha_creacion timestamp DEFAULT now() NOT NULL,
	CONSTRAINT ck_convocatoria_cupos CHECK (((cupos >= 1) AND (cupos <= 50))),
	CONSTRAINT ck_convocatoria_fechas CHECK ((fecha_hasta >= fecha_desde)),
	CONSTRAINT ck_convocatoria_horas CHECK (((horas_requeridas >= 1) AND (horas_requeridas <= 400))),
	CONSTRAINT convocatoria_cupos_not_null NOT NULL cupos,
	CONSTRAINT convocatoria_fecha_creacion_not_null NOT NULL fecha_creacion,
	CONSTRAINT convocatoria_fecha_desde_not_null NOT NULL fecha_desde,
	CONSTRAINT convocatoria_fecha_hasta_not_null NOT NULL fecha_hasta,
	CONSTRAINT convocatoria_horas_requeridas_not_null NOT NULL horas_requeridas,
	CONSTRAINT convocatoria_id_asignatura_not_null NOT NULL id_asignatura,
	CONSTRAINT convocatoria_id_convocatoria_not_null NOT NULL id_convocatoria,
	CONSTRAINT convocatoria_id_coordinador_not_null NOT NULL id_coordinador,
	CONSTRAINT convocatoria_id_periodo_not_null NOT NULL id_periodo,
	CONSTRAINT convocatoria_pkey PRIMARY KEY (id_convocatoria),
	CONSTRAINT convocatoria_requisitos_not_null NOT NULL requisitos,
	CONSTRAINT uq_convocatoria UNIQUE (id_asignatura, id_periodo),
	CONSTRAINT convocatoria_id_asignatura_fkey FOREIGN KEY (id_asignatura) REFERENCES public.asignatura(id_asignatura),
	CONSTRAINT convocatoria_id_coordinador_fkey FOREIGN KEY (id_coordinador) REFERENCES public.usuario(id_usuario),
	CONSTRAINT convocatoria_id_periodo_fkey FOREIGN KEY (id_periodo) REFERENCES public.periodo_academico(id_periodo)
);
CREATE INDEX ix_convocatoria_periodo ON public.convocatoria USING btree (id_periodo);
COMMENT ON TABLE public.convocatoria IS 'Convocatorias de ayudantía publicadas por el coordinador.';

-- Column comments

COMMENT ON COLUMN public.convocatoria.cupos IS 'Número máximo de ayudantes (1 a 50).';
COMMENT ON COLUMN public.convocatoria.horas_requeridas IS 'Horas que debe cumplir cada ayudante.';
COMMENT ON COLUMN public.convocatoria.fecha_desde IS 'Primer día para postularse.';
COMMENT ON COLUMN public.convocatoria.fecha_hasta IS 'Último día para postularse.';


-- public.postulacion definition

-- Drop table

-- DROP TABLE public.postulacion;

CREATE TABLE public.postulacion (
	id_postulacion int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	id_convocatoria int4 NOT NULL,
	id_estudiante int4 NOT NULL,
	fecha_postulacion timestamp DEFAULT now() NOT NULL,
	estado varchar(20) DEFAULT 'Pendiente'::character varying NOT NULL, -- Pendiente, Seleccionado, No seleccionado o En espera.
	puntaje numeric(5, 2) NULL, -- Puntaje de 0 a 100; obligatorio al evaluar.
	observacion varchar(300) NULL,
	documento_nombre varchar(200) NOT NULL,
	documento bytea NOT NULL, -- Documento PDF adjunto (máximo 5 MB).
	CONSTRAINT ck_postulacion_documento CHECK (((octet_length(documento) >= 1) AND (octet_length(documento) <= 5242880))),
	CONSTRAINT ck_postulacion_estado CHECK (((estado)::text = ANY ((ARRAY['Pendiente'::character varying, 'Seleccionado'::character varying, 'No seleccionado'::character varying, 'En espera'::character varying])::text[]))),
	CONSTRAINT ck_postulacion_evaluada CHECK ((((estado)::text = 'Pendiente'::text) OR (puntaje IS NOT NULL))),
	CONSTRAINT ck_postulacion_puntaje CHECK (((puntaje >= (0)::numeric) AND (puntaje <= (100)::numeric))),
	CONSTRAINT postulacion_documento_nombre_not_null NOT NULL documento_nombre,
	CONSTRAINT postulacion_documento_not_null NOT NULL documento,
	CONSTRAINT postulacion_estado_not_null NOT NULL estado,
	CONSTRAINT postulacion_fecha_postulacion_not_null NOT NULL fecha_postulacion,
	CONSTRAINT postulacion_id_convocatoria_not_null NOT NULL id_convocatoria,
	CONSTRAINT postulacion_id_estudiante_not_null NOT NULL id_estudiante,
	CONSTRAINT postulacion_id_postulacion_not_null NOT NULL id_postulacion,
	CONSTRAINT postulacion_pkey PRIMARY KEY (id_postulacion),
	CONSTRAINT uq_postulacion UNIQUE (id_convocatoria, id_estudiante),
	CONSTRAINT postulacion_id_convocatoria_fkey FOREIGN KEY (id_convocatoria) REFERENCES public.convocatoria(id_convocatoria),
	CONSTRAINT postulacion_id_estudiante_fkey FOREIGN KEY (id_estudiante) REFERENCES public.usuario(id_usuario)
);
CREATE INDEX ix_postulacion_estudiante ON public.postulacion USING btree (id_estudiante);
COMMENT ON TABLE public.postulacion IS 'Postulaciones de estudiantes y su evaluación.';

-- Column comments

COMMENT ON COLUMN public.postulacion.estado IS 'Pendiente, Seleccionado, No seleccionado o En espera.';
COMMENT ON COLUMN public.postulacion.puntaje IS 'Puntaje de 0 a 100; obligatorio al evaluar.';
COMMENT ON COLUMN public.postulacion.documento IS 'Documento PDF adjunto (máximo 5 MB).';


-- public.asignacion definition

-- Drop table

-- DROP TABLE public.asignacion;

CREATE TABLE public.asignacion (
	id_asignacion int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	id_postulacion int4 NOT NULL,
	id_docente int4 NOT NULL,
	fecha_asignacion timestamp DEFAULT now() NOT NULL,
	CONSTRAINT asignacion_fecha_asignacion_not_null NOT NULL fecha_asignacion,
	CONSTRAINT asignacion_id_asignacion_not_null NOT NULL id_asignacion,
	CONSTRAINT asignacion_id_docente_not_null NOT NULL id_docente,
	CONSTRAINT asignacion_id_postulacion_key UNIQUE (id_postulacion),
	CONSTRAINT asignacion_id_postulacion_not_null NOT NULL id_postulacion,
	CONSTRAINT asignacion_pkey PRIMARY KEY (id_asignacion),
	CONSTRAINT asignacion_id_docente_fkey FOREIGN KEY (id_docente) REFERENCES public.usuario(id_usuario),
	CONSTRAINT asignacion_id_postulacion_fkey FOREIGN KEY (id_postulacion) REFERENCES public.postulacion(id_postulacion)
);
CREATE INDEX ix_asignacion_docente ON public.asignacion USING btree (id_docente);
COMMENT ON TABLE public.asignacion IS 'Ayudantes asignados a un docente (siguiente versión).';


-- public.registro_horas definition

-- Drop table

-- DROP TABLE public.registro_horas;

CREATE TABLE public.registro_horas (
	id_registro int4 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 2147483647 START 1 CACHE 1 NO CYCLE) NOT NULL,
	id_asignacion int4 NOT NULL,
	fecha date NOT NULL,
	descripcion varchar(500) NOT NULL,
	horas numeric(4, 2) NOT NULL,
	estado varchar(25) DEFAULT 'Pendiente de validación'::character varying NOT NULL,
	observacion varchar(300) NULL,
	fecha_validacion timestamp NULL,
	CONSTRAINT ck_registro_estado CHECK (((estado)::text = ANY ((ARRAY['Pendiente de validación'::character varying, 'Validado'::character varying, 'Rechazado'::character varying])::text[]))),
	CONSTRAINT ck_registro_horas CHECK (((horas > (0)::numeric) AND (horas <= (8)::numeric))),
	CONSTRAINT registro_horas_descripcion_not_null NOT NULL descripcion,
	CONSTRAINT registro_horas_estado_not_null NOT NULL estado,
	CONSTRAINT registro_horas_fecha_not_null NOT NULL fecha,
	CONSTRAINT registro_horas_horas_not_null NOT NULL horas,
	CONSTRAINT registro_horas_id_asignacion_not_null NOT NULL id_asignacion,
	CONSTRAINT registro_horas_id_registro_not_null NOT NULL id_registro,
	CONSTRAINT registro_horas_pkey PRIMARY KEY (id_registro),
	CONSTRAINT registro_horas_id_asignacion_fkey FOREIGN KEY (id_asignacion) REFERENCES public.asignacion(id_asignacion)
);
CREATE INDEX ix_registro_asignacion ON public.registro_horas USING btree (id_asignacion);
COMMENT ON TABLE public.registro_horas IS 'Horas registradas por el ayudante (siguiente versión).';



-- DROP FUNCTION public.armor(bytea, _text, _text);

CREATE OR REPLACE FUNCTION public.armor(bytea, text[], text[])
 RETURNS text
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_armor$function$
;

-- DROP FUNCTION public.armor(bytea);

CREATE OR REPLACE FUNCTION public.armor(bytea)
 RETURNS text
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_armor$function$
;

-- DROP FUNCTION public.crypt(text, text);

CREATE OR REPLACE FUNCTION public.crypt(text, text)
 RETURNS text
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_crypt$function$
;

-- DROP FUNCTION public.dearmor(text);

CREATE OR REPLACE FUNCTION public.dearmor(text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_dearmor$function$
;

-- DROP FUNCTION public.decrypt(bytea, bytea, text);

CREATE OR REPLACE FUNCTION public.decrypt(bytea, bytea, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_decrypt$function$
;

-- DROP FUNCTION public.decrypt_iv(bytea, bytea, bytea, text);

CREATE OR REPLACE FUNCTION public.decrypt_iv(bytea, bytea, bytea, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_decrypt_iv$function$
;

-- DROP FUNCTION public.digest(bytea, text);

CREATE OR REPLACE FUNCTION public.digest(bytea, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_digest$function$
;

-- DROP FUNCTION public.digest(text, text);

CREATE OR REPLACE FUNCTION public.digest(text, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_digest$function$
;

-- DROP FUNCTION public.encrypt(bytea, bytea, text);

CREATE OR REPLACE FUNCTION public.encrypt(bytea, bytea, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_encrypt$function$
;

-- DROP FUNCTION public.encrypt_iv(bytea, bytea, bytea, text);

CREATE OR REPLACE FUNCTION public.encrypt_iv(bytea, bytea, bytea, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_encrypt_iv$function$
;

-- DROP FUNCTION public.fips_mode();

CREATE OR REPLACE FUNCTION public.fips_mode()
 RETURNS boolean
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_check_fipsmode$function$
;

-- DROP FUNCTION public.fn_convocatorias_abiertas(int4, int4);

CREATE OR REPLACE FUNCTION public.fn_convocatorias_abiertas(p_id_estudiante integer, p_id_periodo integer DEFAULT NULL::integer)
 RETURNS TABLE(id_convocatoria integer, "Asignatura" text, "Período" text, "Cupos" integer, "Hasta" date, "Requisitos" text, "Postulado" text)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT cv.id_convocatoria, (a.codigo || ' - ' || a.nombre)::TEXT, p.nombre::TEXT, cv.cupos, cv.fecha_hasta,
           cv.requisitos,
           CASE WHEN EXISTS (SELECT 1 FROM postulacion po
                              WHERE po.id_convocatoria = cv.id_convocatoria AND po.id_estudiante = p_id_estudiante)
                THEN 'Sí' ELSE 'No' END
      FROM convocatoria cv
      JOIN asignatura a        ON a.id_asignatura = cv.id_asignatura
      JOIN periodo_academico p ON p.id_periodo = cv.id_periodo
      JOIN usuario u           ON u.id_usuario = p_id_estudiante AND u.id_carrera = a.id_carrera
     WHERE current_date BETWEEN cv.fecha_desde AND cv.fecha_hasta
       AND (p_id_periodo IS NULL OR cv.id_periodo = p_id_periodo)
     ORDER BY cv.fecha_hasta;
$function$
;

-- DROP FUNCTION public.fn_documento_postulacion(int4);

CREATE OR REPLACE FUNCTION public.fn_documento_postulacion(p_id_postulacion integer)
 RETURNS TABLE(nombre text, contenido bytea)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT po.documento_nombre::TEXT, po.documento FROM postulacion po WHERE po.id_postulacion = p_id_postulacion;
$function$
;

-- DROP FUNCTION public.fn_historial_asignatura(int4, int4);

CREATE OR REPLACE FUNCTION public.fn_historial_asignatura(p_id_asignatura integer, p_id_periodo integer)
 RETURNS TABLE("Período" text, "Postulantes" integer, "Seleccionados" integer)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT p.nombre::TEXT,
           count(po.id_postulacion)::INT,
           count(po.id_postulacion) FILTER (WHERE po.estado = 'Seleccionado')::INT
      FROM convocatoria cv
      JOIN periodo_academico p ON p.id_periodo = cv.id_periodo
      LEFT JOIN postulacion po ON po.id_convocatoria = cv.id_convocatoria
     WHERE cv.id_asignatura = p_id_asignatura
       AND cv.fecha_hasta < current_date
       AND p.fecha_inicio < (SELECT fecha_inicio FROM periodo_academico WHERE id_periodo = p_id_periodo)
     GROUP BY p.nombre, p.fecha_inicio
     ORDER BY p.fecha_inicio;
$function$
;

-- DROP FUNCTION public.fn_iniciar_sesion(text, text);

CREATE OR REPLACE FUNCTION public.fn_iniciar_sesion(p_correo text, p_contrasena text)
 RETURNS TABLE(id_usuario integer, nombres text, apellidos text, id_rol integer, rol text, id_carrera integer, carrera text)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
DECLARE
    v usuario%ROWTYPE;
BEGIN
    SELECT * INTO v FROM usuario u WHERE lower(u.correo) = lower(btrim(p_correo));

    -- crypt() compara la contraseña escrita con la cifrada
    IF NOT FOUND OR v.contrasena_hash <> crypt(p_contrasena, v.contrasena_hash) THEN
        RAISE EXCEPTION 'Correo o contraseña incorrectos.';
    END IF;

    IF NOT v.activo THEN
        RAISE EXCEPTION 'Su cuenta está desactivada. Comuníquese con el administrador.';
    END IF;

    RETURN QUERY
    SELECT v.id_usuario, v.nombres::TEXT, v.apellidos::TEXT, v.id_rol, r.nombre::TEXT, v.id_carrera, c.nombre::TEXT
      FROM rol r
      LEFT JOIN carrera c ON c.id_carrera = v.id_carrera
     WHERE r.id_rol = v.id_rol;
END;
$function$
;

-- DROP FUNCTION public.fn_listar_asignaturas(int4);

CREATE OR REPLACE FUNCTION public.fn_listar_asignaturas(p_id_carrera integer DEFAULT NULL::integer)
 RETURNS TABLE(id_asignatura integer, id_carrera integer, "Código" text, "Asignatura" text, "Nivel" integer, "Carrera" text, "Activa" boolean)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT a.id_asignatura, a.id_carrera, a.codigo::TEXT, a.nombre::TEXT, a.nivel, c.nombre::TEXT, a.activo
      FROM asignatura a
      JOIN carrera c ON c.id_carrera = a.id_carrera
     WHERE p_id_carrera IS NULL OR a.id_carrera = p_id_carrera
     ORDER BY c.nombre, a.nivel, a.nombre;
$function$
;

-- DROP FUNCTION public.fn_listar_carreras(int4);

CREATE OR REPLACE FUNCTION public.fn_listar_carreras(p_id_facultad integer DEFAULT NULL::integer)
 RETURNS TABLE(id_carrera integer, id_facultad integer, "Carrera" text, "Facultad" text, "Activa" boolean)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT c.id_carrera, c.id_facultad, c.nombre::TEXT, f.nombre::TEXT, c.activo
      FROM carrera c
      JOIN facultad f ON f.id_facultad = c.id_facultad
     WHERE p_id_facultad IS NULL OR c.id_facultad = p_id_facultad
     ORDER BY f.nombre, c.nombre;
$function$
;

-- DROP FUNCTION public.fn_listar_convocatorias(int4, int4);

CREATE OR REPLACE FUNCTION public.fn_listar_convocatorias(p_id_carrera integer DEFAULT NULL::integer, p_id_periodo integer DEFAULT NULL::integer)
 RETURNS TABLE(id_convocatoria integer, id_asignatura integer, id_periodo integer, "Asignatura" text, "Período" text, "Carrera" text, "Cupos" integer, "Horas" integer, "Desde" date, "Hasta" date, "Postulantes" integer, "Estado" text, "Requisitos" text)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT cv.id_convocatoria, cv.id_asignatura, cv.id_periodo,
           (a.codigo || ' - ' || a.nombre)::TEXT, p.nombre::TEXT, c.nombre::TEXT,
           cv.cupos, cv.horas_requeridas, cv.fecha_desde, cv.fecha_hasta,
           (SELECT count(*) FROM postulacion po WHERE po.id_convocatoria = cv.id_convocatoria)::INT,
           CASE WHEN current_date < cv.fecha_desde THEN 'Próxima'
                WHEN current_date > cv.fecha_hasta THEN 'Cerrada'
                ELSE 'Abierta' END,
           cv.requisitos
      FROM convocatoria cv
      JOIN asignatura a        ON a.id_asignatura = cv.id_asignatura
      JOIN carrera c           ON c.id_carrera = a.id_carrera
      JOIN periodo_academico p ON p.id_periodo = cv.id_periodo
     WHERE (p_id_carrera IS NULL OR a.id_carrera = p_id_carrera)
       AND (p_id_periodo IS NULL OR cv.id_periodo = p_id_periodo)
     ORDER BY cv.fecha_hasta DESC, a.nombre;
$function$
;

-- DROP FUNCTION public.fn_listar_facultades();

CREATE OR REPLACE FUNCTION public.fn_listar_facultades()
 RETURNS TABLE(id_facultad integer, "Facultad" text, "Activa" boolean)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT f.id_facultad, f.nombre::TEXT, f.activo FROM facultad f ORDER BY f.nombre;
$function$
;

-- DROP FUNCTION public.fn_listar_periodos();

CREATE OR REPLACE FUNCTION public.fn_listar_periodos()
 RETURNS TABLE(id_periodo integer, "Período" text, "Inicio" date, "Fin" date, "Activo" boolean, "Estado" text)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT p.id_periodo, p.nombre::TEXT, p.fecha_inicio, p.fecha_fin, p.activo,
           CASE WHEN current_date > p.fecha_fin THEN 'Finalizado'
                WHEN current_date < p.fecha_inicio THEN 'Próximo'
                ELSE 'Actual' END
      FROM periodo_academico p ORDER BY p.fecha_inicio DESC;
$function$
;

-- DROP FUNCTION public.fn_listar_roles();

CREATE OR REPLACE FUNCTION public.fn_listar_roles()
 RETURNS TABLE(id_rol integer, nombre text)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT r.id_rol, r.nombre::TEXT FROM rol r ORDER BY r.id_rol;
$function$
;

-- DROP FUNCTION public.fn_listar_usuarios();

CREATE OR REPLACE FUNCTION public.fn_listar_usuarios()
 RETURNS TABLE(id_usuario integer, id_rol integer, id_carrera integer, "Cédula" text, "Apellidos" text, "Nombres" text, "Correo" text, "Rol" text, "Carrera" text, "Activo" boolean)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT u.id_usuario, u.id_rol, u.id_carrera, u.cedula::TEXT, u.apellidos::TEXT, u.nombres::TEXT,
           u.correo::TEXT, r.nombre::TEXT, coalesce(c.nombre, '')::TEXT, u.activo
      FROM usuario u
      JOIN rol r ON r.id_rol = u.id_rol
      LEFT JOIN carrera c ON c.id_carrera = u.id_carrera
     ORDER BY u.apellidos, u.nombres;
$function$
;

-- DROP FUNCTION public.fn_mis_postulaciones(int4, int4);

CREATE OR REPLACE FUNCTION public.fn_mis_postulaciones(p_id_estudiante integer, p_id_periodo integer DEFAULT NULL::integer)
 RETURNS TABLE(id_postulacion integer, "Asignatura" text, "Período" text, "Fecha" date, "Estado" text, "Puntaje" numeric, "Observación" text, "Documento" text)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT po.id_postulacion, (a.codigo || ' - ' || a.nombre)::TEXT, p.nombre::TEXT, po.fecha_postulacion::DATE,
           po.estado::TEXT, po.puntaje, coalesce(po.observacion, '')::TEXT, po.documento_nombre::TEXT
      FROM postulacion po
      JOIN convocatoria cv     ON cv.id_convocatoria = po.id_convocatoria
      JOIN asignatura a        ON a.id_asignatura = cv.id_asignatura
      JOIN periodo_academico p ON p.id_periodo = cv.id_periodo
     WHERE po.id_estudiante = p_id_estudiante
       AND (p_id_periodo IS NULL OR cv.id_periodo = p_id_periodo)
     ORDER BY po.fecha_postulacion DESC;
$function$
;

-- DROP FUNCTION public.fn_postulaciones_por_estado(int4, int4);

CREATE OR REPLACE FUNCTION public.fn_postulaciones_por_estado(p_id_usuario integer, p_id_periodo integer)
 RETURNS TABLE(estado text, total integer)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT e.estado, count(po.id_postulacion)::INT
      FROM (VALUES ('Pendiente'), ('Seleccionado'), ('En espera'), ('No seleccionado')) AS e (estado)
      LEFT JOIN (SELECT po.id_postulacion, po.estado
                   FROM postulacion po
                   JOIN convocatoria cv ON cv.id_convocatoria = po.id_convocatoria
                   JOIN asignatura a ON a.id_asignatura = cv.id_asignatura
                  WHERE cv.id_periodo = p_id_periodo
                    AND fn_puede_ver(p_id_usuario, a.id_carrera, po.id_estudiante)) po ON po.estado = e.estado
     GROUP BY e.estado
     ORDER BY array_position(ARRAY['Pendiente', 'Seleccionado', 'En espera', 'No seleccionado'], e.estado);
$function$
;

-- DROP FUNCTION public.fn_postulantes(int4);

CREATE OR REPLACE FUNCTION public.fn_postulantes(p_id_convocatoria integer)
 RETURNS TABLE(id_postulacion integer, "Cédula" text, "Estudiante" text, "Fecha" date, "Estado" text, "Puntaje" numeric, "Observación" text, "Documento" text)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT po.id_postulacion, u.cedula::TEXT, (u.apellidos || ' ' || u.nombres)::TEXT, po.fecha_postulacion::DATE,
           po.estado::TEXT, po.puntaje, coalesce(po.observacion, '')::TEXT, po.documento_nombre::TEXT
      FROM postulacion po
      JOIN usuario u ON u.id_usuario = po.id_estudiante
     WHERE po.id_convocatoria = p_id_convocatoria
     ORDER BY po.puntaje DESC NULLS LAST, u.apellidos;
$function$
;

-- DROP FUNCTION public.fn_prediccion_postulantes(int4, int4);

CREATE OR REPLACE FUNCTION public.fn_prediccion_postulantes(p_id_usuario integer, p_id_periodo integer)
 RETURNS TABLE(id_asignatura integer, "Asignatura" text, "Carrera" text, "Períodos analizados" integer, "Promedio" numeric, "Período anterior" integer, "Predicción" integer, "Real" integer, "Tendencia" text, "Cupos sugeridos" integer)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    WITH periodos AS (        -- número de orden de cada período: 1 = el más antiguo
        SELECT id_periodo, row_number() OVER (ORDER BY fecha_inicio) AS numero
          FROM periodo_academico
    ),
    elegido AS (              -- número del período que se quiere predecir
        SELECT numero FROM periodos WHERE id_periodo = p_id_periodo
    ),
    conteo AS (               -- postulantes por asignatura y período (convocatorias cerradas)
        SELECT cv.id_asignatura, pe.numero,
               count(po.id_postulacion) AS postulantes,
               count(po.id_postulacion) FILTER (WHERE po.estado = 'Seleccionado') AS seleccionados
          FROM convocatoria cv
          JOIN periodos pe ON pe.id_periodo = cv.id_periodo
          LEFT JOIN postulacion po ON po.id_convocatoria = cv.id_convocatoria
         WHERE cv.fecha_hasta < current_date
         GROUP BY cv.id_asignatura, pe.numero
    ),
    calculo AS (              -- recta de mínimos cuadrados con los períodos anteriores al elegido
        SELECT h.id_asignatura,
               count(*) AS periodos,
               avg(h.postulantes) AS promedio,
               max(h.numero) AS ultimo,
               regr_slope(h.postulantes, h.numero) AS pendiente,
               regr_intercept(h.postulantes, h.numero) AS intercepto,
               sum(h.seleccionados)::NUMERIC / nullif(sum(h.postulantes), 0) AS tasa_seleccion
          FROM conteo h
         WHERE h.numero < (SELECT numero FROM elegido)
         GROUP BY h.id_asignatura
    ),
    resultado AS (            -- se proyecta la recta al período elegido
        SELECT k.*,
               greatest(0, round(coalesce(k.intercepto + k.pendiente * (SELECT numero FROM elegido), k.promedio)))::INT
                   AS prediccion
          FROM calculo k
    )
    SELECT a.id_asignatura,
           (a.codigo || ' - ' || a.nombre)::TEXT,
           c.nombre::TEXT,
           r.periodos::INT,
           round(r.promedio, 1),
           (SELECT h.postulantes FROM conteo h WHERE h.id_asignatura = r.id_asignatura AND h.numero = r.ultimo)::INT,
           r.prediccion,
           -- lo que realmente pasó en el período elegido (vacío si aún no se cierra)
           (SELECT h.postulantes FROM conteo h
             WHERE h.id_asignatura = r.id_asignatura AND h.numero = (SELECT numero FROM elegido))::INT,
           CASE WHEN coalesce(r.pendiente, 0) > 0.3 THEN 'Sube'
                WHEN coalesce(r.pendiente, 0) < -0.3 THEN 'Baja'
                ELSE 'Estable' END,
           greatest(1, round(r.prediccion * coalesce(r.tasa_seleccion, 0.5)))::INT
      FROM resultado r
      JOIN asignatura a ON a.id_asignatura = r.id_asignatura
      JOIN carrera c    ON c.id_carrera = a.id_carrera
      JOIN usuario u    ON u.id_usuario = p_id_usuario
     WHERE u.id_rol = 1 OR u.id_carrera = a.id_carrera
     ORDER BY r.prediccion DESC, a.nombre;
$function$
;

-- DROP FUNCTION public.fn_puede_ver(int4, int4, int4);

CREATE OR REPLACE FUNCTION public.fn_puede_ver(p_id_usuario integer, p_id_carrera integer, p_id_estudiante integer)
 RETURNS boolean
 LANGUAGE sql
 STABLE SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT CASE u.id_rol
               WHEN 1 THEN TRUE
               WHEN 4 THEN p_id_estudiante = u.id_usuario
               ELSE u.id_carrera IS NULL OR u.id_carrera = p_id_carrera
           END
      FROM usuario u WHERE u.id_usuario = p_id_usuario;
$function$
;

-- DROP FUNCTION public.fn_reporte_postulaciones(int4, int4, int4, int4, text);

CREATE OR REPLACE FUNCTION public.fn_reporte_postulaciones(p_id_usuario integer, p_id_periodo integer, p_id_carrera integer, p_id_asignatura integer, p_cedula text)
 RETURNS TABLE("Período" text, "Carrera" text, "Asignatura" text, "Cédula" text, "Estudiante" text, "Fecha" date, "Estado" text, "Puntaje" numeric)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT p.nombre::TEXT, c.nombre::TEXT, (a.codigo || ' - ' || a.nombre)::TEXT, u.cedula::TEXT,
           (u.apellidos || ' ' || u.nombres)::TEXT, po.fecha_postulacion::DATE, po.estado::TEXT, po.puntaje
      FROM postulacion po
      JOIN usuario u           ON u.id_usuario = po.id_estudiante
      JOIN convocatoria cv     ON cv.id_convocatoria = po.id_convocatoria
      JOIN asignatura a        ON a.id_asignatura = cv.id_asignatura
      JOIN carrera c           ON c.id_carrera = a.id_carrera
      JOIN periodo_academico p ON p.id_periodo = cv.id_periodo
     WHERE fn_puede_ver(p_id_usuario, a.id_carrera, po.id_estudiante)
       AND (p_id_periodo IS NULL OR cv.id_periodo = p_id_periodo)
       AND (p_id_carrera IS NULL OR a.id_carrera = p_id_carrera)
       AND (p_id_asignatura IS NULL OR a.id_asignatura = p_id_asignatura)
       AND (coalesce(btrim(p_cedula), '') = '' OR u.cedula = btrim(p_cedula))
     ORDER BY p.nombre, c.nombre, a.nombre, u.apellidos;
$function$
;

-- DROP FUNCTION public.fn_resumen_inicio(int4, int4);

CREATE OR REPLACE FUNCTION public.fn_resumen_inicio(p_id_usuario integer, p_id_periodo integer)
 RETURNS TABLE(convocatorias integer, postulaciones integer, por_evaluar integer, seleccionados integer)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $function$
    SELECT
        (SELECT count(*) FROM convocatoria cv JOIN asignatura a ON a.id_asignatura = cv.id_asignatura
          WHERE cv.id_periodo = p_id_periodo
            AND fn_puede_ver(p_id_usuario, a.id_carrera, p_id_usuario))::INT,
        count(*)::INT,
        count(*) FILTER (WHERE x.estado = 'Pendiente')::INT,
        count(*) FILTER (WHERE x.estado = 'Seleccionado')::INT
      FROM (SELECT po.estado
              FROM postulacion po
              JOIN convocatoria cv ON cv.id_convocatoria = po.id_convocatoria
              JOIN asignatura a ON a.id_asignatura = cv.id_asignatura
             WHERE cv.id_periodo = p_id_periodo
               AND fn_puede_ver(p_id_usuario, a.id_carrera, po.id_estudiante)) x;
$function$
;

-- DROP FUNCTION public.gen_random_bytes(int4);

CREATE OR REPLACE FUNCTION public.gen_random_bytes(integer)
 RETURNS bytea
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_random_bytes$function$
;

-- DROP FUNCTION public.gen_random_uuid();

CREATE OR REPLACE FUNCTION public.gen_random_uuid()
 RETURNS uuid
 LANGUAGE c
 PARALLEL SAFE
AS '$libdir/pgcrypto', $function$pg_random_uuid$function$
;

-- DROP FUNCTION public.gen_salt(text);

CREATE OR REPLACE FUNCTION public.gen_salt(text)
 RETURNS text
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_gen_salt$function$
;

-- DROP FUNCTION public.gen_salt(text, int4);

CREATE OR REPLACE FUNCTION public.gen_salt(text, integer)
 RETURNS text
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_gen_salt_rounds$function$
;

-- DROP FUNCTION public.hmac(text, text, text);

CREATE OR REPLACE FUNCTION public.hmac(text, text, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_hmac$function$
;

-- DROP FUNCTION public.hmac(bytea, bytea, text);

CREATE OR REPLACE FUNCTION public.hmac(bytea, bytea, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pg_hmac$function$
;

-- DROP FUNCTION public.pgp_armor_headers(in text, out text, out text);

CREATE OR REPLACE FUNCTION public.pgp_armor_headers(text, OUT key text, OUT value text)
 RETURNS SETOF record
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_armor_headers$function$
;

-- DROP FUNCTION public.pgp_key_id(bytea);

CREATE OR REPLACE FUNCTION public.pgp_key_id(bytea)
 RETURNS text
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_key_id_w$function$
;

-- DROP FUNCTION public.pgp_pub_decrypt(bytea, bytea, text, text);

CREATE OR REPLACE FUNCTION public.pgp_pub_decrypt(bytea, bytea, text, text)
 RETURNS text
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_pub_decrypt_text$function$
;

-- DROP FUNCTION public.pgp_pub_decrypt(bytea, bytea);

CREATE OR REPLACE FUNCTION public.pgp_pub_decrypt(bytea, bytea)
 RETURNS text
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_pub_decrypt_text$function$
;

-- DROP FUNCTION public.pgp_pub_decrypt(bytea, bytea, text);

CREATE OR REPLACE FUNCTION public.pgp_pub_decrypt(bytea, bytea, text)
 RETURNS text
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_pub_decrypt_text$function$
;

-- DROP FUNCTION public.pgp_pub_decrypt_bytea(bytea, bytea, text);

CREATE OR REPLACE FUNCTION public.pgp_pub_decrypt_bytea(bytea, bytea, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_pub_decrypt_bytea$function$
;

-- DROP FUNCTION public.pgp_pub_decrypt_bytea(bytea, bytea, text, text);

CREATE OR REPLACE FUNCTION public.pgp_pub_decrypt_bytea(bytea, bytea, text, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_pub_decrypt_bytea$function$
;

-- DROP FUNCTION public.pgp_pub_decrypt_bytea(bytea, bytea);

CREATE OR REPLACE FUNCTION public.pgp_pub_decrypt_bytea(bytea, bytea)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_pub_decrypt_bytea$function$
;

-- DROP FUNCTION public.pgp_pub_encrypt(text, bytea);

CREATE OR REPLACE FUNCTION public.pgp_pub_encrypt(text, bytea)
 RETURNS bytea
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_pub_encrypt_text$function$
;

-- DROP FUNCTION public.pgp_pub_encrypt(text, bytea, text);

CREATE OR REPLACE FUNCTION public.pgp_pub_encrypt(text, bytea, text)
 RETURNS bytea
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_pub_encrypt_text$function$
;

-- DROP FUNCTION public.pgp_pub_encrypt_bytea(bytea, bytea);

CREATE OR REPLACE FUNCTION public.pgp_pub_encrypt_bytea(bytea, bytea)
 RETURNS bytea
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_pub_encrypt_bytea$function$
;

-- DROP FUNCTION public.pgp_pub_encrypt_bytea(bytea, bytea, text);

CREATE OR REPLACE FUNCTION public.pgp_pub_encrypt_bytea(bytea, bytea, text)
 RETURNS bytea
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_pub_encrypt_bytea$function$
;

-- DROP FUNCTION public.pgp_sym_decrypt(bytea, text, text);

CREATE OR REPLACE FUNCTION public.pgp_sym_decrypt(bytea, text, text)
 RETURNS text
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_sym_decrypt_text$function$
;

-- DROP FUNCTION public.pgp_sym_decrypt(bytea, text);

CREATE OR REPLACE FUNCTION public.pgp_sym_decrypt(bytea, text)
 RETURNS text
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_sym_decrypt_text$function$
;

-- DROP FUNCTION public.pgp_sym_decrypt_bytea(bytea, text);

CREATE OR REPLACE FUNCTION public.pgp_sym_decrypt_bytea(bytea, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_sym_decrypt_bytea$function$
;

-- DROP FUNCTION public.pgp_sym_decrypt_bytea(bytea, text, text);

CREATE OR REPLACE FUNCTION public.pgp_sym_decrypt_bytea(bytea, text, text)
 RETURNS bytea
 LANGUAGE c
 IMMUTABLE PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_sym_decrypt_bytea$function$
;

-- DROP FUNCTION public.pgp_sym_encrypt(text, text, text);

CREATE OR REPLACE FUNCTION public.pgp_sym_encrypt(text, text, text)
 RETURNS bytea
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_sym_encrypt_text$function$
;

-- DROP FUNCTION public.pgp_sym_encrypt(text, text);

CREATE OR REPLACE FUNCTION public.pgp_sym_encrypt(text, text)
 RETURNS bytea
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_sym_encrypt_text$function$
;

-- DROP FUNCTION public.pgp_sym_encrypt_bytea(bytea, text, text);

CREATE OR REPLACE FUNCTION public.pgp_sym_encrypt_bytea(bytea, text, text)
 RETURNS bytea
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_sym_encrypt_bytea$function$
;

-- DROP FUNCTION public.pgp_sym_encrypt_bytea(bytea, text);

CREATE OR REPLACE FUNCTION public.pgp_sym_encrypt_bytea(bytea, text)
 RETURNS bytea
 LANGUAGE c
 PARALLEL SAFE STRICT
AS '$libdir/pgcrypto', $function$pgp_sym_encrypt_bytea$function$
;

-- DROP PROCEDURE public.sp_actualizar_asignatura(int4, int4, text, text, int4, bool);

CREATE OR REPLACE PROCEDURE public.sp_actualizar_asignatura(IN p_id integer, IN p_id_carrera integer, IN p_codigo text, IN p_nombre text, IN p_nivel integer, IN p_activo boolean)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF p_id_carrera IS NULL OR btrim(coalesce(p_codigo, '')) = '' OR btrim(coalesce(p_nombre, '')) = '' THEN
        RAISE EXCEPTION 'Complete la carrera, el código y el nombre de la asignatura.';
    END IF;
    IF EXISTS (SELECT 1 FROM asignatura WHERE id_carrera = p_id_carrera AND upper(codigo) = upper(btrim(p_codigo))
                                          AND id_asignatura <> p_id) THEN
        RAISE EXCEPTION 'Ya existe una asignatura con ese código en la carrera.';
    END IF;

    UPDATE asignatura
       SET id_carrera = p_id_carrera, codigo = upper(btrim(p_codigo)), nombre = btrim(p_nombre),
           nivel = p_nivel, activo = p_activo
     WHERE id_asignatura = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_actualizar_carrera(int4, int4, text, bool);

CREATE OR REPLACE PROCEDURE public.sp_actualizar_carrera(IN p_id integer, IN p_id_facultad integer, IN p_nombre text, IN p_activo boolean)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF p_id_facultad IS NULL OR btrim(coalesce(p_nombre, '')) = '' THEN
        RAISE EXCEPTION 'Complete la facultad y el nombre de la carrera.';
    END IF;
    IF EXISTS (SELECT 1 FROM carrera WHERE id_facultad = p_id_facultad AND lower(nombre) = lower(btrim(p_nombre))
                                       AND id_carrera <> p_id) THEN
        RAISE EXCEPTION 'Ya existe una carrera con ese nombre en la facultad.';
    END IF;

    UPDATE carrera SET id_facultad = p_id_facultad, nombre = btrim(p_nombre), activo = p_activo WHERE id_carrera = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_actualizar_convocatoria(int4, int4, int4, int4, int4, int4, text, date, date);

CREATE OR REPLACE PROCEDURE public.sp_actualizar_convocatoria(IN p_id integer, IN p_id_asignatura integer, IN p_id_periodo integer, IN p_id_coordinador integer, IN p_cupos integer, IN p_horas integer, IN p_requisitos text, IN p_desde date, IN p_hasta date)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    CALL sp_validar_convocatoria(p_id, p_id_asignatura, p_id_periodo, p_id_coordinador, p_cupos, p_horas,
                                 p_requisitos, p_desde, p_hasta);

    UPDATE convocatoria
       SET id_asignatura = p_id_asignatura, id_periodo = p_id_periodo, cupos = p_cupos, horas_requeridas = p_horas,
           requisitos = btrim(p_requisitos), fecha_desde = p_desde, fecha_hasta = p_hasta
     WHERE id_convocatoria = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_actualizar_facultad(int4, text, bool);

CREATE OR REPLACE PROCEDURE public.sp_actualizar_facultad(IN p_id integer, IN p_nombre text, IN p_activo boolean)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF btrim(coalesce(p_nombre, '')) = '' THEN
        RAISE EXCEPTION 'El nombre de la facultad es obligatorio.';
    END IF;
    IF EXISTS (SELECT 1 FROM facultad WHERE lower(nombre) = lower(btrim(p_nombre)) AND id_facultad <> p_id) THEN
        RAISE EXCEPTION 'Ya existe una facultad con ese nombre.';
    END IF;

    UPDATE facultad SET nombre = btrim(p_nombre), activo = p_activo WHERE id_facultad = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_actualizar_periodo(int4, text, date, date, bool);

CREATE OR REPLACE PROCEDURE public.sp_actualizar_periodo(IN p_id integer, IN p_nombre text, IN p_inicio date, IN p_fin date, IN p_activo boolean)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF btrim(coalesce(p_nombre, '')) = '' THEN
        RAISE EXCEPTION 'El nombre del período es obligatorio.';
    END IF;
    IF p_fin <= p_inicio THEN
        RAISE EXCEPTION 'La fecha de fin debe ser posterior a la fecha de inicio.';
    END IF;
    IF EXISTS (SELECT 1 FROM periodo_academico WHERE lower(nombre) = lower(btrim(p_nombre)) AND id_periodo <> p_id) THEN
        RAISE EXCEPTION 'Ya existe un período con ese nombre.';
    END IF;

    UPDATE periodo_academico
       SET nombre = btrim(p_nombre), fecha_inicio = p_inicio, fecha_fin = p_fin, activo = p_activo
     WHERE id_periodo = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_actualizar_usuario(int4, text, text, text, text, int4, int4);

CREATE OR REPLACE PROCEDURE public.sp_actualizar_usuario(IN p_id integer, IN p_cedula text, IN p_nombres text, IN p_apellidos text, IN p_correo text, IN p_id_rol integer, IN p_id_carrera integer)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    CALL sp_validar_usuario(p_id, p_cedula, p_nombres, p_apellidos, p_correo, p_id_rol, p_id_carrera);

    UPDATE usuario
       SET cedula = p_cedula, nombres = btrim(p_nombres), apellidos = btrim(p_apellidos),
           correo = lower(btrim(p_correo)), id_rol = p_id_rol,
           id_carrera = CASE WHEN p_id_rol = 1 THEN NULL ELSE p_id_carrera END
     WHERE id_usuario = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_cambiar_contrasena(int4, text, text);

CREATE OR REPLACE PROCEDURE public.sp_cambiar_contrasena(IN p_id integer, IN p_actual text, IN p_nueva text)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
DECLARE
    v_hash TEXT;
BEGIN
    SELECT contrasena_hash INTO v_hash FROM usuario WHERE id_usuario = p_id;

    IF v_hash IS NULL OR v_hash <> crypt(p_actual, v_hash) THEN
        RAISE EXCEPTION 'La contraseña actual no es correcta.';
    END IF;
    IF length(coalesce(p_nueva, '')) < 8 THEN
        RAISE EXCEPTION 'La nueva contraseña debe tener al menos 8 caracteres.';
    END IF;
    IF p_nueva = p_actual THEN
        RAISE EXCEPTION 'La nueva contraseña debe ser diferente de la actual.';
    END IF;

    UPDATE usuario SET contrasena_hash = crypt(p_nueva, gen_salt('bf')) WHERE id_usuario = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_cambiar_estado_usuario(int4, bool);

CREATE OR REPLACE PROCEDURE public.sp_cambiar_estado_usuario(IN p_id integer, IN p_activo boolean)
 LANGUAGE sql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
    UPDATE usuario SET activo = p_activo WHERE id_usuario = p_id;
$procedure$
;

-- DROP PROCEDURE public.sp_eliminar_asignatura(int4);

CREATE OR REPLACE PROCEDURE public.sp_eliminar_asignatura(IN p_id integer)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF EXISTS (SELECT 1 FROM convocatoria WHERE id_asignatura = p_id) THEN
        RAISE EXCEPTION 'No se puede eliminar: la asignatura tiene convocatorias. Desactívela en su lugar.';
    END IF;

    DELETE FROM asignatura WHERE id_asignatura = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_eliminar_carrera(int4);

CREATE OR REPLACE PROCEDURE public.sp_eliminar_carrera(IN p_id integer)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF EXISTS (SELECT 1 FROM asignatura WHERE id_carrera = p_id) OR EXISTS (SELECT 1 FROM usuario WHERE id_carrera = p_id) THEN
        RAISE EXCEPTION 'No se puede eliminar: la carrera tiene asignaturas o usuarios. Desactívela en su lugar.';
    END IF;

    DELETE FROM carrera WHERE id_carrera = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_eliminar_convocatoria(int4);

CREATE OR REPLACE PROCEDURE public.sp_eliminar_convocatoria(IN p_id integer)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF EXISTS (SELECT 1 FROM postulacion WHERE id_convocatoria = p_id) THEN
        RAISE EXCEPTION 'No se puede eliminar: la convocatoria ya tiene postulaciones.';
    END IF;

    DELETE FROM convocatoria WHERE id_convocatoria = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_eliminar_facultad(int4);

CREATE OR REPLACE PROCEDURE public.sp_eliminar_facultad(IN p_id integer)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF EXISTS (SELECT 1 FROM carrera WHERE id_facultad = p_id) THEN
        RAISE EXCEPTION 'No se puede eliminar: la facultad tiene carreras registradas. Desactívela en su lugar.';
    END IF;

    DELETE FROM facultad WHERE id_facultad = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_eliminar_periodo(int4);

CREATE OR REPLACE PROCEDURE public.sp_eliminar_periodo(IN p_id integer)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF EXISTS (SELECT 1 FROM convocatoria WHERE id_periodo = p_id) THEN
        RAISE EXCEPTION 'No se puede eliminar: el período tiene convocatorias. Desactívelo en su lugar.';
    END IF;

    DELETE FROM periodo_academico WHERE id_periodo = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_eliminar_usuario(int4);

CREATE OR REPLACE PROCEDURE public.sp_eliminar_usuario(IN p_id integer)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF EXISTS (SELECT 1 FROM convocatoria WHERE id_coordinador = p_id)
       OR EXISTS (SELECT 1 FROM postulacion WHERE id_estudiante = p_id) THEN
        RAISE EXCEPTION 'No se puede eliminar: el usuario tiene convocatorias o postulaciones. Desactívelo en su lugar.';
    END IF;

    DELETE FROM usuario WHERE id_usuario = p_id;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_evaluar_postulacion(int4, numeric, text, text);

CREATE OR REPLACE PROCEDURE public.sp_evaluar_postulacion(IN p_id_postulacion integer, IN p_puntaje numeric, IN p_estado text, IN p_observacion text)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF p_estado NOT IN ('Seleccionado', 'No seleccionado', 'En espera') THEN
        RAISE EXCEPTION 'Seleccione el resultado: Seleccionado, No seleccionado o En espera.';
    END IF;
    IF p_puntaje IS NULL OR p_puntaje NOT BETWEEN 0 AND 100 THEN
        RAISE EXCEPTION 'El puntaje debe estar entre 0 y 100.';
    END IF;
    IF EXISTS (SELECT 1 FROM postulacion po
                 JOIN convocatoria cv ON cv.id_convocatoria = po.id_convocatoria
                 JOIN periodo_academico p ON p.id_periodo = cv.id_periodo
                WHERE po.id_postulacion = p_id_postulacion AND p.fecha_fin < current_date) THEN
        RAISE EXCEPTION 'El período de esta convocatoria ya finalizó: solo se puede consultar.';
    END IF;

    UPDATE postulacion
       SET puntaje = p_puntaje, estado = p_estado, observacion = nullif(btrim(coalesce(p_observacion, '')), '')
     WHERE id_postulacion = p_id_postulacion;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_insertar_asignatura(int4, text, text, int4, bool);

CREATE OR REPLACE PROCEDURE public.sp_insertar_asignatura(IN p_id_carrera integer, IN p_codigo text, IN p_nombre text, IN p_nivel integer, IN p_activo boolean)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF p_id_carrera IS NULL OR btrim(coalesce(p_codigo, '')) = '' OR btrim(coalesce(p_nombre, '')) = '' THEN
        RAISE EXCEPTION 'Complete la carrera, el código y el nombre de la asignatura.';
    END IF;
    IF EXISTS (SELECT 1 FROM asignatura WHERE id_carrera = p_id_carrera AND upper(codigo) = upper(btrim(p_codigo))) THEN
        RAISE EXCEPTION 'Ya existe una asignatura con ese código en la carrera.';
    END IF;

    INSERT INTO asignatura (id_carrera, codigo, nombre, nivel, activo)
    VALUES (p_id_carrera, upper(btrim(p_codigo)), btrim(p_nombre), p_nivel, p_activo);
END;
$procedure$
;

-- DROP PROCEDURE public.sp_insertar_carrera(int4, text, bool);

CREATE OR REPLACE PROCEDURE public.sp_insertar_carrera(IN p_id_facultad integer, IN p_nombre text, IN p_activo boolean)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF p_id_facultad IS NULL THEN
        RAISE EXCEPTION 'Seleccione la facultad.';
    END IF;
    IF btrim(coalesce(p_nombre, '')) = '' THEN
        RAISE EXCEPTION 'El nombre de la carrera es obligatorio.';
    END IF;
    IF EXISTS (SELECT 1 FROM carrera WHERE id_facultad = p_id_facultad AND lower(nombre) = lower(btrim(p_nombre))) THEN
        RAISE EXCEPTION 'Ya existe una carrera con ese nombre en la facultad.';
    END IF;

    INSERT INTO carrera (id_facultad, nombre, activo) VALUES (p_id_facultad, btrim(p_nombre), p_activo);
END;
$procedure$
;

-- DROP PROCEDURE public.sp_insertar_convocatoria(int4, int4, int4, int4, int4, text, date, date);

CREATE OR REPLACE PROCEDURE public.sp_insertar_convocatoria(IN p_id_asignatura integer, IN p_id_periodo integer, IN p_id_coordinador integer, IN p_cupos integer, IN p_horas integer, IN p_requisitos text, IN p_desde date, IN p_hasta date)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    CALL sp_validar_convocatoria(NULL, p_id_asignatura, p_id_periodo, p_id_coordinador, p_cupos, p_horas,
                                 p_requisitos, p_desde, p_hasta);

    INSERT INTO convocatoria (id_asignatura, id_periodo, id_coordinador, cupos, horas_requeridas, requisitos,
                              fecha_desde, fecha_hasta)
    VALUES (p_id_asignatura, p_id_periodo, p_id_coordinador, p_cupos, p_horas, btrim(p_requisitos), p_desde, p_hasta);
END;
$procedure$
;

-- DROP PROCEDURE public.sp_insertar_facultad(text, bool);

CREATE OR REPLACE PROCEDURE public.sp_insertar_facultad(IN p_nombre text, IN p_activo boolean)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF btrim(coalesce(p_nombre, '')) = '' THEN
        RAISE EXCEPTION 'El nombre de la facultad es obligatorio.';
    END IF;
    IF EXISTS (SELECT 1 FROM facultad WHERE lower(nombre) = lower(btrim(p_nombre))) THEN
        RAISE EXCEPTION 'Ya existe una facultad con ese nombre.';
    END IF;

    INSERT INTO facultad (nombre, activo) VALUES (btrim(p_nombre), p_activo);
END;
$procedure$
;

-- DROP PROCEDURE public.sp_insertar_periodo(text, date, date, bool);

CREATE OR REPLACE PROCEDURE public.sp_insertar_periodo(IN p_nombre text, IN p_inicio date, IN p_fin date, IN p_activo boolean)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF btrim(coalesce(p_nombre, '')) = '' THEN
        RAISE EXCEPTION 'El nombre del período es obligatorio.';
    END IF;
    IF p_fin <= p_inicio THEN
        RAISE EXCEPTION 'La fecha de fin debe ser posterior a la fecha de inicio.';
    END IF;
    IF EXISTS (SELECT 1 FROM periodo_academico WHERE lower(nombre) = lower(btrim(p_nombre))) THEN
        RAISE EXCEPTION 'Ya existe un período con ese nombre.';
    END IF;

    INSERT INTO periodo_academico (nombre, fecha_inicio, fecha_fin, activo) VALUES (btrim(p_nombre), p_inicio, p_fin, p_activo);
END;
$procedure$
;

-- DROP PROCEDURE public.sp_insertar_usuario(text, text, text, text, text, int4, int4);

CREATE OR REPLACE PROCEDURE public.sp_insertar_usuario(IN p_cedula text, IN p_nombres text, IN p_apellidos text, IN p_correo text, IN p_contrasena text, IN p_id_rol integer, IN p_id_carrera integer)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    CALL sp_validar_usuario(NULL, p_cedula, p_nombres, p_apellidos, p_correo, p_id_rol, p_id_carrera);

    IF length(coalesce(p_contrasena, '')) < 8 THEN
        RAISE EXCEPTION 'La contraseña debe tener al menos 8 caracteres.';
    END IF;

    INSERT INTO usuario (cedula, nombres, apellidos, correo, contrasena_hash, id_rol, id_carrera)
    VALUES (p_cedula, btrim(p_nombres), btrim(p_apellidos), lower(btrim(p_correo)),
            crypt(p_contrasena, gen_salt('bf')), p_id_rol, CASE WHEN p_id_rol = 1 THEN NULL ELSE p_id_carrera END);
END;
$procedure$
;

-- DROP PROCEDURE public.sp_postular(int4, int4, text, bytea);

CREATE OR REPLACE PROCEDURE public.sp_postular(IN p_id_convocatoria integer, IN p_id_estudiante integer, IN p_documento_nombre text, IN p_documento bytea)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
DECLARE
    v_desde DATE;
    v_hasta DATE;
BEGIN
    IF p_id_convocatoria IS NULL THEN
        RAISE EXCEPTION 'Seleccione una convocatoria.';
    END IF;
    IF p_documento IS NULL OR lower(coalesce(p_documento_nombre, '')) NOT LIKE '%.pdf' THEN
        RAISE EXCEPTION 'Adjunte su documento en formato PDF.';
    END IF;
    IF octet_length(p_documento) > 5242880 THEN
        RAISE EXCEPTION 'El documento no puede superar 5 MB.';
    END IF;
    IF NOT EXISTS (SELECT 1 FROM usuario u
                     JOIN asignatura a ON a.id_carrera = u.id_carrera
                     JOIN convocatoria cv ON cv.id_asignatura = a.id_asignatura
                    WHERE u.id_usuario = p_id_estudiante AND u.id_rol = 4 AND u.activo
                      AND cv.id_convocatoria = p_id_convocatoria) THEN
        RAISE EXCEPTION 'Solo puede postular a convocatorias de su carrera.';
    END IF;

    SELECT fecha_desde, fecha_hasta INTO v_desde, v_hasta FROM convocatoria WHERE id_convocatoria = p_id_convocatoria;
    IF current_date NOT BETWEEN v_desde AND v_hasta THEN
        RAISE EXCEPTION 'La convocatoria está fuera del plazo de postulación (% al %).', v_desde, v_hasta;
    END IF;
    IF EXISTS (SELECT 1 FROM postulacion WHERE id_convocatoria = p_id_convocatoria AND id_estudiante = p_id_estudiante) THEN
        RAISE EXCEPTION 'Ya se postuló a esta convocatoria.';
    END IF;

    INSERT INTO postulacion (id_convocatoria, id_estudiante, documento_nombre, documento)
    VALUES (p_id_convocatoria, p_id_estudiante, p_documento_nombre, p_documento);
END;
$procedure$
;

-- DROP PROCEDURE public.sp_retirar_postulacion(int4, int4);

CREATE OR REPLACE PROCEDURE public.sp_retirar_postulacion(IN p_id_postulacion integer, IN p_id_estudiante integer)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF NOT EXISTS (SELECT 1 FROM postulacion WHERE id_postulacion = p_id_postulacion
                      AND id_estudiante = p_id_estudiante AND estado = 'Pendiente') THEN
        RAISE EXCEPTION 'Solo puede retirar sus postulaciones que aún no han sido evaluadas.';
    END IF;

    DELETE FROM postulacion WHERE id_postulacion = p_id_postulacion;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_validar_convocatoria(int4, int4, int4, int4, int4, int4, text, date, date);

CREATE OR REPLACE PROCEDURE public.sp_validar_convocatoria(IN p_id integer, IN p_id_asignatura integer, IN p_id_periodo integer, IN p_id_coordinador integer, IN p_cupos integer, IN p_horas integer, IN p_requisitos text, IN p_desde date, IN p_hasta date)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
DECLARE
    v_inicio DATE;
    v_fin    DATE;
    v_activo BOOLEAN;
BEGIN
    IF p_id_asignatura IS NULL OR p_id_periodo IS NULL THEN
        RAISE EXCEPTION 'Seleccione la asignatura y el período.';
    END IF;
    IF NOT EXISTS (SELECT 1 FROM asignatura a JOIN usuario u ON u.id_carrera = a.id_carrera
                    WHERE a.id_asignatura = p_id_asignatura AND u.id_usuario = p_id_coordinador) THEN
        RAISE EXCEPTION 'Solo puede crear convocatorias para asignaturas de su carrera.';
    END IF;
    IF p_cupos NOT BETWEEN 1 AND 50 THEN
        RAISE EXCEPTION 'Los cupos deben estar entre 1 y 50.';
    END IF;
    IF p_horas NOT BETWEEN 1 AND 400 THEN
        RAISE EXCEPTION 'Las horas requeridas deben estar entre 1 y 400.';
    END IF;
    IF btrim(coalesce(p_requisitos, '')) = '' THEN
        RAISE EXCEPTION 'Escriba los requisitos de la convocatoria.';
    END IF;
    IF p_hasta < p_desde THEN
        RAISE EXCEPTION 'La fecha "hasta" no puede ser anterior a la fecha "desde".';
    END IF;

    SELECT fecha_inicio, fecha_fin, activo INTO v_inicio, v_fin, v_activo
      FROM periodo_academico WHERE id_periodo = p_id_periodo;

    IF NOT v_activo THEN
        RAISE EXCEPTION 'El período seleccionado está inactivo.';
    END IF;
    IF p_desde < v_inicio OR p_hasta > v_fin THEN
        RAISE EXCEPTION 'Las fechas de postulación deben estar dentro del período (% al %).', v_inicio, v_fin;
    END IF;
    IF EXISTS (SELECT 1 FROM convocatoria WHERE id_asignatura = p_id_asignatura AND id_periodo = p_id_periodo
                                            AND id_convocatoria <> coalesce(p_id, 0)) THEN
        RAISE EXCEPTION 'Ya existe una convocatoria para esa asignatura en el período.';
    END IF;
END;
$procedure$
;

-- DROP PROCEDURE public.sp_validar_usuario(int4, text, text, text, text, int4, int4);

CREATE OR REPLACE PROCEDURE public.sp_validar_usuario(IN p_id integer, IN p_cedula text, IN p_nombres text, IN p_apellidos text, IN p_correo text, IN p_id_rol integer, IN p_id_carrera integer)
 LANGUAGE plpgsql
 SECURITY DEFINER
 SET search_path TO 'public'
AS $procedure$
BEGIN
    IF coalesce(p_cedula, '') !~ '^[0-9]{10}$' THEN
        RAISE EXCEPTION 'La cédula debe tener 10 dígitos.';
    END IF;
    IF btrim(coalesce(p_nombres, '')) = '' OR btrim(coalesce(p_apellidos, '')) = '' THEN
        RAISE EXCEPTION 'Los nombres y apellidos son obligatorios.';
    END IF;
    IF coalesce(p_correo, '') !~* '^[^@[:space:]]+@[^@[:space:]]+\.[^@[:space:]]+$' THEN
        RAISE EXCEPTION 'El correo no tiene un formato válido.';
    END IF;
    IF p_id_rol IN (2, 4) AND p_id_carrera IS NULL THEN
        RAISE EXCEPTION 'Los coordinadores y estudiantes deben tener una carrera.';
    END IF;
    IF EXISTS (SELECT 1 FROM usuario WHERE cedula = p_cedula AND id_usuario <> coalesce(p_id, 0)) THEN
        RAISE EXCEPTION 'La cédula ya está registrada en otro usuario.';
    END IF;
    IF EXISTS (SELECT 1 FROM usuario WHERE lower(correo) = lower(btrim(p_correo)) AND id_usuario <> coalesce(p_id, 0)) THEN
        RAISE EXCEPTION 'El correo ya está registrado en otro usuario.';
    END IF;
END;
$procedure$
;