
import { ReactNode } from "react"
import styles from "./BasketButton.module.css"

interface BasketButtonProps {
    children?: ReactNode; 
    btnAction: (e: React.MouseEvent<HTMLButtonElement, MouseEvent>) => void
}

const BasketButton = ({ children, btnAction }: BasketButtonProps) => {
    return (
        <button className={styles.btn} onClick={(e) => btnAction(e)}>
            <div className={styles.content}>
                {
                    children
                }
            </div>
        </button>
    )
}

export default BasketButton;