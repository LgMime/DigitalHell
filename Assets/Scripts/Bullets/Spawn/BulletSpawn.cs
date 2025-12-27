using System.Collections;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    private BulletRotate bulletRotate;

    private void Awake()
    {
        bulletRotate = GetComponent<BulletRotate>();  
    }

    // Добавили аргумент targetPos - куда лететь
    public void SpawnBullet(BulletData data, Vector3 targetPos)
    {
        // Достаем пулю из пула
        GameObject bulletObj = ObjectPool.Instance.SpawnFromPool(
            data.bulletPrefab.name, 
            transform.position, 
            bulletRotate.GetRotation()
        );

        // ВМЕСТО SetEnemy ищем наш новый базовый класс
        // Это сработает и для StandartProjectile, и для PiercingProjectile
        ProjectileBase projectile = bulletObj.GetComponent<ProjectileBase>();
        
        if (projectile != null)
        {
            // Запускаем через новый метод Launch
            // Передаем (Позиция, Скорость, Урон)
            projectile.Launch(targetPos, data.speed, data.damage);
        }
        else
        {
            Debug.LogError("На префабе пули нет скрипта ProjectileBase (или наследника)!");
        }
    }
}