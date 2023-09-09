Angry Bomb é um jogo de física, assim como os seus antecessores (Angry Birds), no qual seu objetivo é eliminar pássaros amarelos e destruir suas construções ao arremessar bombas contra elas.

Os "papeis" se inverteram, e agora é o "Birds" que está sendo eliminado!

Use o mouse para arremessar as bombas, clicando no meio do estilingue!


run game: https://alfredo1995.itch.io/angry-bomb 

<br>

Configurando área do jogo
 
<br>
  
1) Novo projeto 
             
            crie um template do tipo 2D

2) Importar os assets 
            
            faça o download dos assets nesse repositorio

3) Plano de fundo do jogo

            Arraste o plano de fundo para cena e nomeie p/ "PlanoFundo"

4) Arraste as 2 parte do estilingue para hieraquia e posicione na scena

            no estilingue0 > Ordene in layer para 3
            no estilingue1 > Ordene in layer para 1
      
            Anexar o estilingue0 como filho do estilingue1 (Tornado um só objeto)
            Resertar a posição dos objetos no componente tranform ao adiciona-los a cena
            
5) Criar um Empty Object e nomei p/ Estilingue

           trazer o estilingue0e1, p/ dentro desse Empty Object vazio Estilingue
           
6) Criar os objetos que vão receber o componente de renderização de linha
            
            //Dentro Object Estilingue que está armazendo todos os objetos refrente ao estilingue
            
            Create > Empty object > effects > line > nomei para faixa0
            Create > Empty object > effects > line > nomei para faixa1
            
7) Criar os objetos que vão defini a posição entre as faixas de tiras do estilingui
            
            //Dentro Object Estilingue que está armazendo todos os objetos refrente ao estilingue

            Create > Empty object > nomei para PosicaoFaixaCentro
            posicione o objeto PosicaoFaixaCentro no centro superior entre o vao do Estilingue
            
            Create > Empty object > nomei para PosicaoFaixaParada
            posicione o objeto PosicaoFaixaParada no centro a esquerda do estilingui 
            
8) Criar os objetos que vão defini a posição das pontas da faixas de tiras do estilingui
            
            //Dentro Object Estilingue que está armazendo todos os objetos refrente ao estilingue

            Create > Empty object > nomei para PosicaoPontaFaixa0
            posicione o objeto PosicaoPontaFaixa0 na ponta a esquerda do estilingui 
            
            Create > Empty object > nomei para PosicaoPontaFaixa1
            posicione o objeto PosicaoPontaFaixa0 na ponta a direita do estilingui 
            
            Certifique que todos os objetos criados estão dentro do Objeto Estiligui            
<br>

LineRenderer tem uma matriz de dois ou mais pontos no espaço 3D, serve p/ desenhar uma simples linha reta

<br>
            
9) Criar uma pasta e nomei para scripts 

            Dentro da pasta scripts > Crie um novo script c# e nomei para Estiligui.cs            
            Arrast e conecte o script no Objecto Estiligui que esta armazendo todos os componentes
            
10) Abra o script Estiligui.cs e crie um componenteRenderer que tem um array(matriz)            
            
            // Crie uma variavel public p/ armezar os elementos da matriz do tipo LineRenderer            
                        public LineRenderer[] faixas;
                        
            // Crie 3 variavel do tipo Transform para armazenar e manipular a posição, rotação e escala do Estiligui.cs            
                        public Transform[] pontasFaixas;
                        public Transform faixaParada;
                        public Transform faixaCentro;                        

           // crie um bool como mouse para baixo
                        bool mousePrecionado;
                        
11) Mostrando codigo completo Estiligui.cs
           
            public class Estiligui : MonoBehaviour
            {
                public LineRenderer[] faixas;
                public Transform[] pontasFaixas;
                public Transform faixaParada;
                public Transform faixaCentro;  
                
                bool mousePrecionado;
                
12) Definir a contagem e posição dos renderizadores de linha no metodo de inicialização 
            
            //defina a contagem de ambos redenizador para 2 (positionCount)
            //defina a posição da linha dos renderizadores p/ a posição da faixa(setPosition(striPositions.position)

            void Start()
            {
                faixas[0].positionCount = 2;
                faixas[1].positionCount = 2;
                faixas[0].SetPosition(0, pontasFaixas[0].position);
                faixas[1].SetPosition(0, pontasFaixas[1].position);                   
                
13) Crie um metódo para redefinir e definir a faixa atráves de um paramêtro do tipo Vector3     
            
            //Vector3 usada em toda a Unidade para passar posições e direções 3D ao redor
            
            void FaixaPosicoes(Vector3 position)
            {
                //definir a posição das faixas pelo renderizadores de linhas com argumento do paremetro                 
                lineRenderers[0].SetPosition(1, position);
                lineRenderers[1].SetPosition(1, position);
                
14) crie um metodo pegar a posição da faixa e passe a posição da faixa parada como argumento

            void ResertarPosicaoFaixa()
            {
                FaixaPosicoes(faixaParada.position);
            }
<br>

obter a posição do mouse através da propriedade da classe Input

<br>

15) crie um metodo padrao p/ o mouse p/ baixo ou mouse p/ cima

            private void OnMouseDown()
            {
                mousePrecionado = true;
            } 
            
            private void OnMouseUp()
            {
                mousePrecionado = false;
            } 
            
           // esses metodos são chaamados pela unity quando o mouse interage com objeto do jogo
            // foi criado um bool como mouse para baixo no topo do scrip:  bool mousePrecionado;
            
16) Definido condição com o mouse para baixo ou para cima

           // chame o metodo resertarPosicaoFaixa na setença do condicional else            
           // posição do mouse do tipo Vector3 recebendo o Input.mousePosition que retorna a posição do mouse
           // defina o vector z para 10           
           //chame metodo DefinirPosicaoFaixas passando a posição do mouse como argumento na setença do condicional if    

           void Update()
           {
                if (isMouseDown)
                {    
                     Vector3 mousePosition = Input.mousePosition;
                     mousePosition.z = 10;
                     
                     FaixaPosicoes(mousePosition);                
                }else
                {
                   ResertarPosicaoFaixa();
                }
            }         
 <br>
 
 Unity Editor
 
 <br>
                            
17) No Unity Editor atribua todos campos no inspector do objeto Estiligui em seu componente script Estiligui.cs

            arraste o gameobjeto faixa0 para referencia-lo > Line Renderers > Element 0
            arraste o gameobjeto faixa1 para referencia-lo > Line Renderers > Element 1
            
            arraste o gameobjeto PosicaoPontaFaixa0 para referencia-lo > Strip Position  > Element 0
            arraste o gameobjeto PosicaoPontaFaixa1 para referencia-lo > Strip Position > Element 1
            
            arraste o gameobjeto PosicaoFaixaCentro para referencia-lo > Strip Position > faixaCentro
            arraste o gameobjeto PosicaoFaixaParada para referencia-lo > Strip Position > faixaParada


18) Adicione um componente BoxColider 2D no gameObjeto Estiligui
            
            Ajuste o edit colider e marque como true a caixinha " isTrigger"
            
20) clique no inspector do gameObjeto faixa0 e faixa1

            marque a caixinha "Use Word Space" para definir uma posição mundial
            definar a Ordem in Layer para 1
            
21) clique no inspector do gameObjeto faixa1    

            definar a Ordem in Layer para 5

22) No scrpit Estiligui.cs conveta o ponto da tela p/ a posição mundial 

            //No metodo de atualização use o camera.main.screen para definir a posição da faixa ao usar o mouse
            
            void Update()
            {
                if (isMouseDown)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10;
                
                mousePositon = Camera.main.ScreeToWorldPoint(mousePosition);
                
                FaixaPosicoes(mousePosition);

            }
            
            //otimize o tamanho da faixa no inspecto unity > objetos faixa0 e 1 em > End Cap Verticies -3
            //otimize o tamanho da faixa no inspecto unity > objetos faixa0 e 1 em > Widht 0.20
            //otimize o tamanho da faixa no inspecto unity > objetos faixa0 e 1 em > Color > black
            
<br>

Configurando extremidadeFaixa da faixa 

<br>

23) criar um Vector3 de tres posição atuais que armazene a extremidade da faixa

            public Vector3 extremidadeFaixa;
            
24) Ponto mudial extremidadeFaixa p/ a posição atual do(mousePostion) passando como argumento p/ DefinirPosicaoFaixas

            void Update()
            {
                if (isMouseDown)
            {
                Vector3 mousePosition = Input.mousePosition;
                mousePosition.z = 10;
                
                extremidadeFaixa = mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                
                FaixaPosicoes(extremidadeFaixa);
            }
            
25) no metodo resertarPosicaoFaixa obter a posição PosicaoParadaFaixa, passando o argumento como parametro

            void resertarPosicaoFaixa()
            {
               extremidadeFaixa = faixaParada.position;
               FaixaPosicoes(extremidadeFaixa);
            }
            
26) crieu um novo link flutuante que armazene o comprimento maximo da faixa

            public float maxLength;
            
27) Defina a posição atual da extremidadeFaixa no metodo de atualização


            //defina a posição atual (extremidadeFaixa) p/ a posição do ponto central(center.position)
            //adicionando a posição atual(Vector3), grampeando a magintude(ClampMagnitude) p/ saber o comprimento maximo(maxLength)

            void Update()
                if (isMouseDown)
                {
                   extremidadeFaixa = Camera.main.ScreenToWorldPoint(mousePosition);
                   extremidadeFaixa = faixaCentro.position + Vector3.ClampMagnitude(extremidadeFaixa - faixaCentro.position, maxLength);
                
                
            //voltando na unity no inspector do estilingui > estilingui.cs > defini o Max Length para 3
            
28) Limitar o elastico do estilingui ate o solo

            public float tamanhoFaixaSolo;
            
           void Update(){
              if (mousePrecionado)
              {
                  extremidadeFaixa = ClampBoundary(extremidadeFaixa);
            
29) criar o metodo de fixação de limite

             
            Vector3 ClampBoundary(Vector3 vector)
            {
               vector.y = Mathf.Clamp(vector.y, tamanhoFaixaSolo, 1000);
               return vector;
            }
               
            //no editor unity > estilingui > componente > tamanhoFaixaSolo > -3.5
            
<br>        

Configurando mecânicas do Player no jogo ou lógica de instanciar novos objetos

<br>
                      
30) arraste o gameobjet represantndo um passaro(player) da pasta assets para scena

            definar o Orden in Layer para 2
            
31) Adcione no passaro um rigibody2D e um circle collider2D

            edit o collider2D no formato do player
            edit o Rigibory mudando de Dynamic para IsKinematic            
            
32) Crie uma pasta prefabs 

            arraste o player para dentro da pasta prefabs
            
33) Crie um novo material Phisycs Material 2D

            Assets > create > Phisycs Material 2D
            Nomei o Phisycs Material 2D para "Passaro"
            no inspecto defina > Bouciness > 0.3
            no inspecto defina > Frictiton > 0.4
            
34) selecione a pasta assets e crie um Phisycs Material 2D
            
            // Create > Phisycs Material 2D > Nomei para "passaro"
            
            prefabs > passaro > insperctor > circle collider > Material > arraste o Phisycs Material 2D
            prefabs > passaro > insperctor > Rigibory 2D > Material > arraste o Phisycs Material 2D


35) Abra o script Estiligui crie um novo objeto bird prefab no topo do codigo

            public GameObject passaroPrefabs;
            
34) Crie um passaro do tipo Rigibody e um passarocollisor para o tipo Collider

            Rigidbody2D passaro;
            Collider2D passaroCollider;
            
36) crie um novo metodo para instaciar novos passaro(player)

            void CriarPassaros()
            {
                passaro = Instantiate(passaroPrefabs).GetComponent<Rigidbody2D>();
            
37) crie o metodo definindo o colissor do passaro apontando para o colisor 2D
 
            void CriarPassaros()
            {
                passaro = Instantiate(passaroPrefabs).GetComponent<Rigidbody2D>();
                passaroCollider = passaro.GetComponent<Collider2D>();
            
                //defina o colisor do passaro habilitando p/ false assim não teremos o colisor do passaro ao clicar no Estilingue 
            
                passaroCollider.enabled = false;

38) crie uma vairavel public do tipo float para o deslocamento da passaro no topo do script

            public float posicaoDeslocamentoPassaro;
            
39) No metodo DefinirPosicaoFaixas, crie um novo vector3 dir recebendo a posição menos PosicaoCentroFaixa 
            
            // defina a posição do passaro p/ position e normalize a direção multiplicando pelo deslocamento do passaro
            // defina a posição do passaro em right recebendo a direçao para normalizar o mouse(-dir.normalized;)

            void DefinirPosicaoFaixas(Vector3 position)
            {
                lineRenderers[0].SetPosition(1, position);
                lineRenderers[1].SetPosition(1, position);

                Vector3 dir = position - center.position;
                
                passaro.transform.position = position + dir.normalized * posicaoDeslocamentoPassaro;
                passaro.transform.right = -dir.normalized;
            
40) adicione uma condição para vericar ser o objeto passaro e nulo

            void DefinirPosicaoFaixas(Vector3 position)
            {
                lineRenderers[0].SetPosition(1, position);
                lineRenderers[1].SetPosition(1, position);

            if (passaro)
            {       
                Vector3 dir = position - posicaoFaixaCentro.position;
                passaro.transform.position = position + dir.normalized * passaroDeslocandoPosicao;
                passaro.transform.right = -dir.normalized;
            }
            }
            
41) No metodo start inicialize o metodo de criação do passaro    

            void Start()
            {
                CriarPassaros();
            }    
            
42) na unity atribua prefab do passaro(player) no componente Estilingui.cs

            selecione Estilingui > inspector > componente Estilingui.cs > PassaroPrefab > 
            Selecione o passaro na pasta prefabs e arraste o objeto passaro o campo PassaroPrefab
            
            ainda no inspecto > ajuste o deslocamento do passaro no campo passaroDeslocandoPosicao

<br>

criar um mecanismo de disparo de passaro

<br>

43) Adicionar uma varivel float no topo do script

            public float force; 
            
44) criar um novo metodo para atirar e chame no metodo OnMouseUp

            void AtirarPassaro()
            {
            }
            
            private void OnMouseDown()
            {
              isMouseDown = true;
             }
            private void OnMouseUp()
            {
                mousePrecionado = false;
                AtirarPassaro();
                
                extremidadeFaixa = FaixaParada.position;
            }
            
45) No metodo AtirarPassaro

            // crie um vector3 chamando a força do passaro 
            // passando a posição atual menos posição central 
            // mutiplicando a força por -1 (para q atire na posição oposta puxada)

            void AtirarPassaro()
            {
                Vector3 passaroForce = (currentPosition - center.position) * force * -1;
            
46) Definir a força da velocidade de dispaaro no passaro

            void AtirarPassaro()
            {
            Vector3 birdForce = (currentPosition - center.position) * force * -1;
            passaro.velocity = passaroForce;
            
             passaro = null;
             passaroCollider = null;
            
47) Invocando o metodo para que vai instaciar os passaros

            //defina o colissor do passaro p/ a entrada de toque q vai invocar o metodo CriarPassaro apos 2 segundos

            void AtirarPassaro()
            {
                Vector3 passaroForce = (currentPosition - center.position) * force * -1;
                passaro.velocity = passaroForce;

                passaro = null;
                passaroCollider = null;
                Invoke("CriarPassaro", 2);
            }

48) Volte na unity e defina a força deseja

            Estilingui > insperctor > componente script > Force > 5
            
<br> 
 
49) Condicionar o rigibory para Cinematico, habilitando o passaroCollider
            
            // implemente condicional if (passaroColider){ passaroCollider.enabled = true;}
            
            void Update()
            {
               if (mousePrecionado)
            {
                   Vector3 mousePosition = Input.mousePosition;
                   mousePosition.z = 10;

                   extremidadeFaixa = Camera.main.ScreenToWorldPoint(mousePosition);
                   extremidadeFaixa = faixaCentro.position + Vector3.ClampMagnitude(extremidadeFaixa - faixaCentro.position, tamanhoFaixa);

                   extremidadeFaixa = ClampBoundary(extremidadeFaixa);
                   FaixaPosicoes(extremidadeFaixa);

                   if (passaroColider)
                   {
                       passaroColider.enabled = true;
                   }
             }
             else
             {
                ResetarPosicaoFaixa();
             }
           }    
            
50) seta o rigibory do passaro para cinematico no metodo CriarPassaro (atente-se com a ordem do codigo)

            void CriarPassaro()
            {
                passaro.isKinematic = true;
            }
            
51) No metodo Atirar desabilite o cinematico antes de disparar o passaro

            void Atirar()
            {
                passaro.isKinematic = false;   
                
52) Chamar metodo ResetarPosicao(); para restar a posição no metodo CriarBolas()

            void CriarBolas()
                {
                    bola = Instantiate(bolaPrefabs).GetComponent<Rigidbody2D>();
                    bolaColide = bola.GetComponent<Collider2D>();
                    bolaColide.enabled = false;

                    bola.isKinematic = true;

                    ResetarPosicao();
                }
                
52) Dectectar colisão do passaro com o chão

            selecione o gameobjet papelParede > box colider2D >  
            marque como > is Trigger > edit a altura do colider posicionado no chao onde o passaro ira colidir

53) adicione alguns objetos para serem derrubados

            arraste os objetos para cena > posicione os objeto na cena e orden in layer para 5
            adicione um rigibory 2D nos objetos 
            para que os objetos nao caia adicione o componente > polygon Collider 2D
            
<br>   

ADICIONANDO UM CONTADOR DE BOLA PARA CHAMAR A TELA DE GAME OVER

<br>

        using UnityEngine.SceneManagement;
        using UnityEngine;

        private int quantidadeDeBolas; //<============= ALTERAÇÕES

        void Start()
        {
            quantidadeDeBolas = 5; //<============= ALTERAÇÕES    


            void AitrarBolas()
            {
                if (quantidadeDeBolas > 0)//<============= ALTERAÇÕES
                {
                    if (bola == null)
                    {
                        return;
                    }
                    else
                    {
                        quantidadeDeBolas--;

                        bola.isKinematic = false;
                        Vector3 bolaForce = (extremidadeFaixa - faixaCentro.position) * force * -1;
                        //bola.velocity = bolaForce;
                        bola.AddForce(bolaForce, ForceMode2D.Impulse);

                        bola.GetComponent<Bola>().BolaInicializada();

                        bola = null;
                        bolaColide = null;
                        Invoke("CriarBolas", 2);
                    }
                }
                else if (quantidadeDeBolas <= 0) //<============= ALTERAÇÕES
                {
                    //CHAMAR TELA DE GAME OVER
                    SceneManager.LoadScene("GameOver");

                }
            }

<br>

Chamando as cenas atraves de index

<br>
       
      private int nextSceneToLoad;

      public void Start()
      {
          nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
      }

      public void ContadorBloco()
      {
          contadorNumero++;

        if (contadorNumero >= passaroIndex)
        {
            SceneManager.LoadScene(nextSceneToLoad);
            //SceneManager.LoadScene("Cena1");

        }
            contadoTexto.text = "PASSAROS : " + contadorNumero;
        }
