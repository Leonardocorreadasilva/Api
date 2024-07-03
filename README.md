# Avaliacao 1 - Arquitetura de Software
## Alunos
- Leonardo Correa da Silva
- Paulo Ricardo Novaes Lisecki
## Introdução

Esta documentação descreve as operações CRUD (Criar, Ler, Atualizar, Excluir) que podem ser realizadas na API de uma aplicação estilo e-commerce. A API permite que usuários gerenciem produtos, carrinhos de compras, pedidos e outras funcionalidades comuns em plataformas de e-commerce.

## Recursos

A API fornece recursos para gerenciar os seguintes dados:
- Usuários: Nome, endereço, e-mail, senha, telefone, tipo de conta (comprador, vendedor)
- Produtos: Título, descrição, preço, categoria, imagens, estoque, marca, estado (novo, usado), visibilidade (público, privado)
- Categorias de Produtos: Criacao de categorias de produtos, listagem de categorias e produtos nelas
- Pedidos: Itens do pedido, status do pedido (pendente, em processamento, enviado, entregue, cancelado), forma de pagamento, histórico de rastreamento
- Review: Avaliacao dos produtos

## Operações
As operações CRUD podem ser realizadas em cada recurso usando os seguintes métodos HTTP:

- **GET**: Ler dados
- **POST**: Criar dados
- **PUT**: Atualizar dados
- **DELETE**: Excluir dados

### Os endereços de API para cada recurso são os seguintes:
- Usuários: `/usuarios`
- Produtos: `/produtos`
- Perguntas e Respostas: `/produtos/{produtoId}/perguntas-respostas`
- Carrinho de Compras: `/carrinho`
- Pedidos: `/pedidos`
- Pagamentos: `/pedidos/{pedidoId}/pagamentos`
- Mensagens: `/mensagens`

## Brainsorm

![alt text](https://github.com/Leonardocorreadasilva/Api/blob/master/image1.png)

