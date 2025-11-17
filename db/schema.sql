CREATE TABLE usuario (
  id_usuario SERIAL PRIMARY KEY,
  nome TEXT NOT NULL,
  email TEXT NOT NULL UNIQUE,
  senha_hash TEXT NOT NULL,
  criado_em TIMESTAMP NOT NULL DEFAULT now()
);
CREATE TABLE mensagem (
  id_mensagem SERIAL PRIMARY KEY,
  id_usuario INT NOT NULL REFERENCES usuario(id_usuario) ON DELETE CASCADE,
  conteudo TEXT NOT NULL,
  criado_em TIMESTAMP NOT NULL DEFAULT now()
);
CREATE TABLE curtida (
  id_usuario INT NOT NULL REFERENCES usuario(id_usuario) ON DELETE CASCADE,
  id_mensagem INT NOT NULL REFERENCES mensagem(id_mensagem) ON DELETE CASCADE,
  criado_em TIMESTAMP NOT NULL DEFAULT now(),
  PRIMARY KEY (id_usuario, id_mensagem)
);
CREATE TABLE comentario (
  id_comentario SERIAL PRIMARY KEY,
  id_mensagem INT NOT NULL REFERENCES mensagem(id_mensagem) ON DELETE CASCADE,
  id_usuario INT NOT NULL REFERENCES usuario(id_usuario) ON DELETE CASCADE,
  texto TEXT NOT NULL,
  criado_em TIMESTAMP NOT NULL DEFAULT now()
);
