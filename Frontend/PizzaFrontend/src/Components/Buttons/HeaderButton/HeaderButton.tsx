
import { Link } from "react-router-dom";
import styles from "./HeaderButton.module.css";
import { ReactNode } from "react";

interface HeaderButtonProps {
    children: ReactNode,
    text: string,
    path: string
}

const HeaderButton = ({ children, text, path }: HeaderButtonProps) => {
    return (
        <Link to={path} className={styles.main}>
            <div className={styles.imageContainer}>
                {
                    children
                }
            </div>
            <p className={styles.text}>
                {text}
            </p>
        </Link>
    )
}

export default HeaderButton;