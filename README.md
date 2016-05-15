# Семинарска работа по Визуелно програмирање - Aera Avis

### Опис на апликацијата

Предмет на оваа семинарска работа е изработка на Windows Forms апликацијата/играта Aera Avis.Оваа играа претставува имплементација на познатата игра Flappy Bird.Flappy Bird e јасен концепт на игра со натпреваруавчки карактер и без одреден крај, што впрочем и ја прави 'заразна' за секој оној кој се обидува да направи повисок скор од веќе постоечкиот постигнат преку птицата која ги одминува препреките, а сето тоа како резултат на едноставно и континуирано притискање на тачскринот од смартфон или таблет.Нашата апликација е со поразличен и повпечатлив дизајн и додаени се Powerups кој ќе му помогнат или одмогнат на играчот.
Почетната форма се сосоти од копчиња за започнување на нова игра и за преглед на најдобрите резултати.Птицата се движи нагоре со кликање на копчето "+" , доколку се судри со некој од столбовите тогаш таа умира и се појавува форма која го покажува
постигнатиот резултат и најдобриот претходен.

![screenshot_1](https://cloud.githubusercontent.com/assets/19243784/15275658/e2e7f192-1ad1-11e6-81ee-71c3111da0a3.png)

##### Изглед и функција на PowerUps

* ![power1](https://cloud.githubusercontent.com/assets/19243784/15275702/32c26cbe-1ad3-11e6-955c-4c12cba0112a.png) - се менува изгледот на птицата и може да лета доколку го држиме копчето притиснато

* ![power2](https://cloud.githubusercontent.com/assets/19243784/15275712/6b08683a-1ad3-11e6-9f46-0c1c71a79c32.png) - негативна траекторија на движење и на клик иде надоле

* ![power3](https://cloud.githubusercontent.com/assets/19243784/15275738/283453a6-1ad4-11e6-8b6c-aac851bbb974.png) - се менува големината на столбовите и изгледот на птицата

* ![13219826_10208032370879708_977792873_n](https://cloud.githubusercontent.com/assets/19243784/15275835/8cdf1d98-1ad6-11e6-90fb-ac88b1cbccd4.png) - се намалува птицата

* ![13235934_10208032370919709_1579785517_n](https://cloud.githubusercontent.com/assets/19243784/15275836/8e22f56c-1ad6-11e6-9dbe-6466c71e4a4e.png) - се зголемува птицата

### Опис на решението
За реализација на решението користени се класите Bird.cs , Pipes.cs , PowerUp.cs кој се состојат од 
податоци кој ја опишуваат неговата локација и изглед како и соодветните методи за исцртување , движење и др на објектите.Класата Scene.cs претставува контејнер на сите  објекти и методи потребни за играње.Некој од побитни податоци се листата на сите PowerUp  и листа на сите Pipes.
Методите:
* PipesGeneration() - со кој се исцртуваат столбовите на соодветните позиции.
* Intersect() - проверува дали птицата ќе земе некој од powerpup-ите.
* ShouldDie() – проверува дали птицата ги поминала границите на формата или се судрила со некој од столбовите.
* PipePassed() – проверува дали поминала соодветен столб што би значело зголемување на поените.
* Check() – проверува дали некој од столбовите ја поминал границата и се брише .
За сите методи има xml summary за нивно објаснување

##### Опис на класата Bird.cs
Оваа класа го опфаќа основниот модел - птицата. Се симулира движење на птицата со помош на методот Move() во кој се повикува еден од методите MoveUp() или MoveDown() во зависност од правецот во кој сакаме прицата да лета.
Методот RotateImage() врши ротација на слика која ќе се прати како аргумент.
Тајмерот се користи за промена на PoweredUp состојбата, која настапува кога ќе се земе некој од PowerUp-ите регулирана во PowerUp() методод, во нормалната состојба. Оваа состојба трае 7.5 секунди.

```
class Bird
    {
        private Image birdImage;
        private Image currentImage;
        private Rectangle position;
        private Point point;
        private Size size;
        private int birdX;
        private int birdY;
        public int diff;
        private int angle;
        public bool intersect;
        Timer timer;

        public Bird(int x, int y)
        {
            birdImage = Properties.Resources.ActorNormalRes;
            size = new Size(50, 50);
            birdX = x / 2 - 50 / 2;
            birdY = y / 2 - 50 / 2;
            point = new Point(birdX, birdY);
            position = new Rectangle(point, size);
            angle = 0;
            currentImage = birdImage;
            intersect = false;
            timer = new Timer(7500);
            timer.Elapsed += Start;

        }

        private void Start(object sender, ElapsedEventArgs e)
        {
            intersect = false;
            size = new Size(50, 50);
            currentImage = Properties.Resources.ActorNormalRes;
            birdImage = currentImage;
            timer.Stop();
        }

        public void SetSize(Size newSIze)
        {
            size = newSIze;
        }

        public Point GetPoint()
        {
            return point;
        }

        public Size GetSize()
        {
            return size;
        }

        /// <summary>
        /// method to rotate an image either clockwise or counter-clockwise
        /// </summary>
        /// <param name="img">the image to be rotated</param>
        /// <param name="rotationAngle">the angle (in degrees).
        /// NOTE: 
        /// Positive values will rotate clockwise
        /// negative values will rotate counter-clockwise
        /// </param>
        /// <returns></returns>
        public Image RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Rectangle rec = new Rectangle(0, 0, img.Width, img.Height);

            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);

            //now we set the rotation point to the center of our image
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            //now rotate the image
            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            //set the InterpolationMode to HighQualityBicubic so to ensure a high
            //quality image once it is transformed to the specified size

            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //now draw our new image onto the graphics object
            gfx.DrawImage(img, rec);

            //dispose of our Graphics object
            gfx.Dispose();

            //return the image
            return bmp;
        }

        private void Rotate(int degrees)
        {
            if(angle <= 90)
            birdImage = RotateImage(birdImage, degrees);
        }

        private void MoveUp()
        {
            birdY -= 11;

            birdImage = currentImage;
            Rotate(-30);

            diff = 0;
            angle = 0;
        }

        private void MoveDown()
        {
            birdY += 8;
            angle += 10;
            Rotate(10);
        }

       
        public void Move(bool direction)
        {
            if (direction) MoveUp();
            else MoveDown();
            point = new Point(birdX, birdY);
            position = new Rectangle(point, size);
        }

        public void Fly(Graphics g)
        {
            g.DrawImage(birdImage, position);
        }

        public Rectangle GetPosition()
        {
            return position;
        }

        public void PowerUp(Image img)
        {
            timer.Start();
            currentImage = img;
            birdImage = currentImage;
            intersect = true;
        }         
    }
 ```
#### Изработиле: Виктор Петрески 141082 , Никола Јолевски 141105
