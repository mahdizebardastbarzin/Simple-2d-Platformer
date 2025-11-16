# 🎮 Simple 2D Platformer / بازی ساده دو بعدی

A minimal 2D platformer game built with Unity using only primitive shapes. No external assets required!  
یک بازی ساده پلتفرمر دو بعدی ساخته شده با یونیتی که فقط از اشکال اولیه استفاده می‌کند. بدون نیاز به فایل‌های خارجی!

**English one-liner:** A lightweight and customizable 2D platformer built entirely with Unity primitives.  
**فارسی تک‌خطی:** یک بازی ساده و قابل تغییر پلتفرمر دو بعدی با استفاده از اشکال اولیه یونیتی.

---

## 🎮 Game Controls / کنترل‌های بازی

- **Left/Right Arrow Keys / کلیدهای چپ/راست**: Move / حرکت
- **Space / فاصله**: Jump / پرش

---

## ⚙️ How to Set Up in Unity / راه‌اندازی در یونیتی

1. Create a new 2D project in Unity
2. Copy the provided C# scripts into your Assets folder
3. Set up the following GameObjects in your scene:

### 👤 Player Setup / راه‌اندازی بازیکن
1. Create a 2D Object > Sprites > Square  
   - یک شیء دو بعدی > اسپرایت‌ها > مربع ایجاد کنید
2. Rename it to "Player"  
   - نام آن را به "Player" تغییر دهید
3. Add a Rigidbody2D component  
   - کامپوننت Rigidbody2D را اضافه کنید
4. Add a BoxCollider2D component  
   - کامپوننت BoxCollider2D را اضافه کنید
5. Add the PlayerController script  
   - اسکریپت PlayerController را اضافه کنید
6. Create a child empty GameObject named "GroundCheck" and position it at the bottom of the player  
   - یک شیء خالی به نام "GroundCheck" به عنوان فرزند ایجاد کرده و آن را در پایین بازیکن قرار دهید
7. Set the Ground Check reference in the PlayerController  
   - مرجع Ground Check را در PlayerController تنظیم کنید
8. Tag the player as "Player"  
   - تگ "Player" را به بازیکن اختصاص دهید

### 💎 Collectibles / آیتم‌های جمع کردنی
1. Create a 2D Object > Sprites > Circle  
   - یک شیء دو بعدی > اسپرایت‌ها > دایره ایجاد کنید
2. Rename it to "Collectible"  
   - نام آن را به "Collectible" تغییر دهید
3. Add a CircleCollider2D (set as Trigger)  
   - یک CircleCollider2D اضافه کنید (حالت Trigger را فعال کنید)
4. Add the Collectible script  
   - اسکریپت Collectible را اضافه کنید
5. Duplicate to create multiple collectibles  
   - برای ایجاد چندین آیتم قابل جمع‌آوری، آن را کپی کنید

### ⚠️ Hazards / موانع خطرناک
1. Create a 2D Object > Sprites > Triangle  
   - یک شیء دو بعدی > اسپرایت‌ها > مثلث ایجاد کنید
2. Rename it to "Hazard"  
   - نام آن را به "Hazard" تغییر دهید
3. Add a PolygonCollider2D  
   - یک PolygonCollider2D اضافه کنید
4. Add the Hazard script  
   - اسکریپت Hazard را اضافه کنید
5. Set the color to red in the Sprite Renderer  
   - رنگ آن را در Sprite Renderer به قرمز تغییر دهید

### 🌍 Ground / زمین
1. Create a 2D Object > Sprites > Square  
   - یک شیء دو بعدی > اسپرایت‌ها > مربع ایجاد کنید
2. Scale it to create a ground platform  
   - آن را بزرگ‌تر کنید تا به عنوان سکوی زمینی استفاده شود
3. Add a BoxCollider2D  
   - یک BoxCollider2D اضافه کنید
4. Create a new Layer called "Ground" and assign it to this object  
   - یک لایه جدید به نام "Ground" ایجاد کرده و به این شیء اختصاص دهید
5. Set the Ground Layer in the PlayerController's Ground Layer mask  
   - لایه Ground را در ماسک Ground Layer در PlayerController تنظیم کنید

### 🖥️ UI Setup / راه‌اندازی رابط کاربری
1. Create a Canvas  
   - یک Canvas ایجاد کنید
2. Add a TextMeshPro - Text for the score display  
   - یک TextMeshPro - Text برای نمایش امتیاز اضافه کنید
3. Create a panel with a "Game Over" text and a "Restart" button  
   - یک پنل با متن "Game Over" و دکمه "Restart" ایجاد کنید
4. Set up the GameManager references in the Inspector  
   - مراجع GameManager را در Inspector تنظیم کنید

---

## ⭐ Game Features / ویژگی‌های بازی

- Player movement and jumping / حرکت و پرش بازیکن
- Collectible items with score / آیتم‌های قابل جمع‌آوری با امتیاز
- Hazard obstacles / موانع خطرناک
- Score system / سیستم امتیازدهی
- Game over screen / صفحه پایان بازی
- Simple UI / رابط کاربری ساده

---

## 📝 Notes / نکات

- The game uses only Unity's built-in primitive shapes  
  - بازی فقط از اشکال اولیه یونیتی استفاده می‌کند
- No external assets required  
  - نیازی به فایل‌های خارجی ندارد
- All scripts are well-commented for easy modification  
  - تمام اسکریپت‌ها به خوبی کامنت‌گذاری شده‌اند تا به راحتی قابل تغییر باشند.

## 🤝 Contributing

Contributions are welcome! Please read our [Contributing Guidelines](https://github.com/mahdizebardastbarzin/mahdizebardastbarzin/blob/main/CONTRIBUTING.md) to get started.

## 🤝 مشارکت

مشارکت‌های شما خوش‌آمد است! لطفاً [راهنمای مشارکت](https://github.com/mahdizebardastbarzin/mahdizebardastbarzin/blob/main/CONTRIBUTING.md) را مطالعه کنید.

