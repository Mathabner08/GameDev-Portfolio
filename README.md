# GameDev-Portfolio
Repositório destinado à scripts e códigos utilizados em jogos feitos na Unity (game Engine), como sistema de movimentação, câmera, coletor de itens, etc.

Neste script de movimentação, optei pelo CharacterController ao invés do Rigidbody para evitar comportamentos físicos imprevisíveis e garantir um movimento mais 'arcade' e responsivo.

Nota sobre Rotação:
- Separei a rotação horizontal da vertical. A rotação horizontal é aplicada no playerBody (o objeto pai) para que, quando eu ande para frente (W), ele ande na direção que estou olhando;
- A rotação vertical é aplicada apenas na câmera (localRotation) e limitada com Mathf.Clamp para evitar rotações de 360 graus verticais.
