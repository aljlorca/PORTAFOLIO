# Generated by Django 4.1.2 on 2022-10-17 03:01

from django.db import migrations, models


class Migration(migrations.Migration):

    initial = True

    dependencies = [
    ]

    operations = [
        migrations.CreateModel(
            name='Producto',
            fields=[
                ('id_producto', models.CharField(max_length=120, primary_key=True, serialize=False)),
                ('imagen_producto', models.ImageField(blank=True, max_length=150, null=True, upload_to='productos')),
            ],
        ),
    ]
